using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlat : MonoBehaviour
{
    private Collider2D platCollider;

    void Start()
    {
        platCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            // �����ƽ̨�·�����Դ���
            if (collision.contacts[0].point.y < transform.position.y)
            {
                Debug.Log("ignore");
                Physics2D.IgnoreCollision(collision.collider, platCollider, true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("not ignore");
            Physics2D.IgnoreCollision(collision.collider, platCollider, false);
        }
    }
}
