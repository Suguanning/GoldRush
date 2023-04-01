using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public float speed = 1f;
    public float xDistance = 1f;
    public float yDistance = 1f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(xDistance, yDistance, 0f);
    }

    void Update() {
        if (movingRight) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition) {
                movingRight = false;
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition) {
                movingRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+ new Vector3(xDistance, yDistance, 0f), 0.5f);

    }
}
