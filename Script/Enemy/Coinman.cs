using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinman : MonoBehaviour
{
    public LayerMask playerLayer;
    public LayerMask enemyLayer;
    public Vector3 patrol0;
    public Vector3 patrol1;
    private Vector3 pos;
    private Collider2D coll;
    private Collider2D playerColl;
    public float patSpeed=1;
    public float runSpeed;
    public float vision;
    public float restTime;
    public int restCnt;
    public GameObject target;
    public Rigidbody2D rb;
    public Animator anim;

    public float detHeigh;
    public int patProcess = 0;
    public bool isPat0Arrive;
    public bool isPat1Arrive;
    public bool isDetected =false;
    public bool isFaceRight = true;

    private bool isInit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        pos = transform.position;
        isInit = true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0, detHeigh, 0);
        Vector3 down = new Vector3(0, -detHeigh, 0);
        //检测玩家
        if (isFaceRight)
        {
            Vector2 end = new Vector2(transform.position.x + vision, transform.position.y);

            isDetected = Physics2D.OverlapArea(transform.position, end, playerLayer)|| 
                Physics2D.OverlapArea(transform.position+up, end+(Vector2)up, playerLayer) ||
                Physics2D.OverlapArea(transform.position + down, end + (Vector2)down, playerLayer);
        }
        else
        {
            Vector2 end = new Vector2(transform.position.x - vision, transform.position.y);
            isDetected = Physics2D.OverlapArea(transform.position, end, playerLayer) ||
            Physics2D.OverlapArea(transform.position + up, end + (Vector2)up, playerLayer) ||
            Physics2D.OverlapArea(transform.position + down, end + (Vector2)down, playerLayer);
        }
            //巡逻点
            isPat0Arrive = Physics2D.OverlapCircle(pos + patrol0, 0.5f,enemyLayer);
            isPat1Arrive = Physics2D.OverlapCircle(pos + patrol1, 0.5f,enemyLayer);
        //Flip Check
        if(patProcess != 5)
        {
            if (rb.velocity.x > 0 && !isFaceRight)
            {
                Flip();
            }
            else if (rb.velocity.x < 0 && isFaceRight)
            {
                Flip();
            }
        }
        else
        {
            float tmp = (target.transform.position - transform.position).x;
            if (tmp > 0 && !isFaceRight && abs(tmp) > 0.3)
            {
                Flip();
                TurnAnimate();
            }
            else if (tmp < 0 && isFaceRight && abs(tmp) > 0.3)
            {
                Flip();
                TurnAnimate();
            }
        }


        if(patProcess == 0)//Rest
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            restCnt++;
            anim.SetBool("Walk", false);
            anim.SetFloat("Speed", abs(rb.velocity.x));
            anim.SetBool("Turning", false);
            anim.SetBool("Turned", false);
            if (restCnt * Time.deltaTime >= restTime)
            {
                patProcess++;
                restCnt = 0; 
            }

        }else if(patProcess == 1)
        {
            float dir = ((pos+patrol0) - transform.position).x > 0 ? 1:-1 ;
            rb.velocity = new Vector2(dir * patSpeed, rb.velocity.y);
            anim.SetFloat("Speed", abs(rb.velocity.x));
            anim.SetBool("Walk", true);
            if (isPat0Arrive)
                patProcess++;
        }
        else if(patProcess == 2)//Rest
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            restCnt++;
            anim.SetBool("Walk", false);
            anim.SetFloat("Speed", abs(rb.velocity.x));
            if (restCnt * Time.deltaTime >= restTime)
            {
                patProcess++;
                restCnt = 0;
            }
        }
        else if(patProcess == 3)
        {
            float dir = ((pos+patrol1) - transform.position).x > 0 ? 1 : -1;
            rb.velocity = new Vector2(dir * patSpeed, rb.velocity.y);
            anim.SetFloat("Speed", abs(rb.velocity.x));
            anim.SetBool("Walk", true);
            if (isPat1Arrive)
                patProcess = 0;
        }

        if (isDetected && patProcess < 4)
        {
            patProcess = 4;
            TurnAnimate();
        }

        if (patProcess == 4) {
            
            ChaseTarget();
        }
        if(patProcess == 5)//抓住，变金
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetFloat("Speed", 0);
            anim.SetBool("Walk", false);
            anim.SetBool("Turning", true);
            anim.SetBool("Turned",true);
            //patProcess++;
        }
    }
    void OnDone()
    {
        Debug.Log("done");
    }
    private void ChaseTarget()
    {
        Vector3 tar = target.transform.position;
        if(abs(tar.x - transform.position.x) > 0.3)
        {
            float dir = tar.x - transform.position.x > 0 ? 1 : -1;
            rb.velocity = new Vector2(dir * runSpeed, rb.velocity.y);
            anim.SetBool("Walk", false);
            anim.SetFloat("Speed", abs(rb.velocity.x));
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Walk", false);
            anim.SetFloat("Speed", abs(rb.velocity.x));
        }
    }
    private float abs(float num)
    {
        if (num > 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFaceRight = !isFaceRight;
            // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            patProcess = 5;
            TurnAnimate();
            //Physics2D.IgnoreCollision(coll,collision.collider,true);
            playerColl = collision.collider;
            OnCatchPlayer(isFaceRight);
        }
    }
    void TurnAnimate()
    {
        LeanTween.scaleY(gameObject, 1.3f, 0.1f).setEase(LeanTweenType.easeOutBounce).setOnComplete(TurnComplete);
    }
    void TurnComplete()
    {
        LeanTween.scaleY(gameObject, 1f, 0.1f).setEase(LeanTweenType.easeOutBounce);
    }
    private void OnCatchPlayer(bool dir)
    {
        GameEvents.current.CoinmanEnter(dir);
    }
    private void OnReset()
    {
        patProcess = 0;
        if (playerColl != null)
            Physics2D.IgnoreCollision(coll, playerColl, false);
    }
    void OnDrawGizmos()
    {
        Vector3 up = new Vector3(0, detHeigh, 0);
        Gizmos.color = Color.blue;
        if (isFaceRight)
        {
            Vector3 endPoint = new Vector3(transform.position.x + vision, transform.position.y, transform.position.z);
            Gizmos.DrawLine(transform.position, endPoint);
            Gizmos.DrawLine(transform.position+ up, endPoint+ up);
            Gizmos.DrawLine(transform.position- up, endPoint- up);
        }
        else
        {
            Vector3 endPoint = new Vector3(transform.position.x - vision, transform.position.y, transform.position.z);
            Gizmos.DrawLine(transform.position, endPoint);
            Gizmos.DrawLine(transform.position + up, endPoint + up);
            Gizmos.DrawLine(transform.position - up, endPoint - up);
        }
        Gizmos.color = Color.red;
        if (!isInit)
        {
            Gizmos.DrawWireSphere(transform.position + patrol0, 0.5f);
            Gizmos.DrawWireSphere(transform.position + patrol1, 0.5f);
        }
        else
        {
            Gizmos.DrawWireSphere(pos + patrol0, 0.5f);
            Gizmos.DrawWireSphere(pos + patrol1, 0.5f);
        }
    }
}
