using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncePlat : MonoBehaviour
{
    public float collTime;
    public float notCollTime;
    public bool isColl;
    public float platMaxExistTime = 0.5f;
    public Collision coll;
    private SpriteRenderer render;
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        collTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 碰撞后累加到超过最大存留时间则使平台失效
        if (isColl) collTime += 0.02f;
        if (collTime > platMaxExistTime)
        {
            render.enabled = false;
            box.enabled = false;
            isColl = false;
            collTime = 0;
            return;
        }

        // 平台失效后类型到超过最大失效时间后重新激活平台
        if (!render.enabled) notCollTime += 0.02f;
        if (notCollTime > platMaxExistTime)
        {
            render.enabled = true;
            box.enabled = true;
            notCollTime = 0;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColl = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // isColl = false;
    }
}
