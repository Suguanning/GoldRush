using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashPlat : MonoBehaviour
{
    public Vector3 hitpos;
    public BoxCollider2D boxColl;
    public Collision coll;
    private void Start()
    {
        boxColl = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitpos = collision.bounds.ClosestPoint(transform.position);
        Debug.Log(boxColl.bounds.min.y);
        Debug.Log("y=" + collision.transform.position.y);

        if (collision.transform.position.y <= boxColl.bounds.min.y && coll.onGround)
        {

            GameEvents.current.SquashPlatEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.current.SquashPlatExit();
    }
}
