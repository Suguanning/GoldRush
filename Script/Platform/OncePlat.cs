using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncePlat : MonoBehaviour
{
    public float coll_time;
    public bool is_coll;
    public Collision coll;
    private SpriteRenderer render;
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        coll_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (is_coll) coll_time += 0.02f;
        if (coll_time > 1f)
        {
            render.enabled = false;
            box.enabled = false;
            is_coll = false;
            coll_time = 0;
            return;
        }
        Debug.Log(render.enabled);
        bool tmp = render.enabled;
        if (coll.onGround&&!tmp)
        {
            render.enabled = true;
            box.enabled = true;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_coll = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_coll = false;
    }
}
