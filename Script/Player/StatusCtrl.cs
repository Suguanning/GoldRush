using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusCtrl : MonoBehaviour
{

    [Space]
    public string mode = "play";
    private Movement move;
    private Collision coll;
    private CoinRotate rotate;
    [Space]
    [Header("Booleans")]
    public bool isAlive = true;
    public bool isSquashing = false;
    public bool doSq = false;
    public bool doRc = false;
    [Space]
    [Header("Stats")]
    public float health = 100;
    public float coinManDamage = 5;
    public Vector3 bornPosition;
    public float squashTime = 0.5f;
    public float recoverTime = 3.0f;
    public float squashKeep = 3.0f;
    public float blowSpeed = 35;
    public int showNumber;
    private int recoverCnt = 0;
    public float initHealth = 100;

    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        coll = GetComponent<Collision>();
        trans = GetComponent<Transform>();
        rotate = GetComponentInChildren<CoinRotate>();
     
        LeanTween.init(1800);
        GameEvents.current.OnShowTrigerEnter += OnShowModeEnter;
        GameEvents.current.OnShowTrigerExit += OnShowModeExit;
        GameEvents.current.OnDangerPlatEnter += OnDangerPlatEnter;
        GameEvents.current.OnSquashPlatEnter += OnSquashPlatEnter;
        GameEvents.current.OnSquashPlatExit += OnSquashPlatExit;
        GameEvents.current.OnCoinmanEnter += OnCoinmanEnter;
        GameEvents.current.OnMarkToCoin += OnMarkToCoin;
        GameEvents.current.OnReset += ResetStatus;
        health = initHealth;
        GameEvents.current.SetHealth(initHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(mode == "play")
        {
            
        }
        else if(mode == "show")
        {

        }
        if (doSq)
        {
            health -= 10;
            GameEvents.current.SetHealth(health);
            doSq = false;
        }
        if (doRc)
        {
            health += 10;
            GameEvents.current.SetHealth(health);
            doRc = false;
        }
        if (isAlive)
        {
            if (health < 0.1)
            {
                isAlive = false;
            }
        }
        else
        {
            ResetStatus();
        }
    }
    private void FixedUpdate()
    {
        if (!isSquashing)
        {
            if (recoverCnt * Time.fixedDeltaTime < squashKeep && recoverCnt > -0.5f)
            {
                recoverCnt++;
                
            }else if(recoverCnt * Time.fixedDeltaTime >= squashKeep)
            {
                SquashRecover();
                recoverCnt = -1;
            }
        }
    }

    private void ResetStatus()
    {
        health = 100;
        isAlive = true;
        trans.position = bornPosition;
        move.rb.velocity = new Vector2(0, 0);
        GameEvents.current.SetHealth(health);
        //GameEvents.current.Reset();
    }
    //CallBack functions
    private void OnShowModeEnter(int showNum)
    {
        showNumber = showNum;
        move.rb.velocity = new Vector2(0, 0);
        move.enabled = false;
        mode = "show";
    }
    private void OnShowModeExit()
    {
        if(showNumber >= 4)
        {
            mode = "play";
            move.enabled = true;
        }
    }
    private void OnDangerPlatEnter()
    {
        health = 0;
        isAlive = false;
        GameEvents.current.SetHealth(0);
    }

    private void OnDangerPlatExit()
    {

    }

    private void OnSquashPlatEnter()
    {
        rotate.autoRotate = false;
        rotate.enabled = false;
        move.rb.velocity = new Vector2(0, 0);
        move.rb.gravityScale = 3;
        move.enabled = false;
        isSquashing = true;
        recoverCnt = 0;
        LeanTween.scaleX(gameObject, 1.7f, squashTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 0.3f, squashTime).setEase(LeanTweenType.easeOutBounce);
    }
  
    private void OnSquashPlatExit()
    {
        move.enabled = true;
        isSquashing = false;
    }
    private void SquashRecover()
    {
        rotate.autoRotate = true;
        rotate.enabled = true;
        LeanTween.scaleX(gameObject, 1, recoverTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 1, recoverTime).setEase(LeanTweenType.easeOutBounce);
    }

    
    private void OnMovePlatEnter()
    {

    }

    private void OnMovePlatExit()
    {

    }

    private void OnCoinmanEnter(bool dir)
    {
        health -= coinManDamage;
        GameEvents.current.SetHealth(health);
        float tmp = blowSpeed * (dir ? 1 : -1);
        move.rb.velocity = new Vector2(tmp , blowSpeed);
        StartCoroutine(BlowWait());
    }
    IEnumerator BlowWait()
    {
        move.enabled = false;
        move.GetComponent<BetterJumping>().enabled = false;
        move.rb.gravityScale = 3;
        yield return new WaitForSeconds(1.0f);
        move.GetComponent<BetterJumping>().enabled = true;
        move.enabled = true;
    }
    private void OnCoinmanExit()
    {

    }
    private void OnMarkToCoin()
    {
       // ResetStatus();
       move.enabled = false;
       move.rb.gravityScale = 3;
    }
}
