using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 1;
    public float barSpeed = 3;
    public Vector3 scaleMax;
    public Vector3 pos;
    public Rigidbody2D rb;
    public RectTransform trans;
    void Start()
    {
        
        GameEvents.current.OnSetHealth+=OnSetHealth;
        trans = GetComponent<RectTransform>();
        scaleMax = trans.localScale;
        pos = trans.localPosition;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 theScale = transform.localScale;
        Vector3 transScale;
        Vector3 move;


        theScale.x = (health) * scaleMax.x;
        transScale = Vector3.Lerp(trans.localScale, theScale, barSpeed * Time.deltaTime);
        trans.localScale = transScale;
        Debug.Log("size:" + trans.rect.width);
        Debug.Log("scale:" + trans.localScale+"Max:"+scaleMax);
        move = new Vector3(((transScale.x - scaleMax.x)* trans.rect.width / 2), 0, 0);
        Debug.Log("move:"+move+"trans:"+trans.position);
        trans.localPosition = move + pos;
        //trans.Translate(move);
            //transform.Translate(move);

    }
    void OnSetHealth(float h)
    {
        health = h / 100;
        if(health < 0)
        {
            health = 0;
        }
    }
}
