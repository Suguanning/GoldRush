using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriger : MonoBehaviour
{
    // Start is called before the first frame update
    public  float xOffset;
    public float yOffset;
    public float size = 2;
    public Vector3 tmp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.current.ChangeCamera(xOffset, yOffset, size);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 center = transform.position + new Vector3(xOffset, yOffset, 0);
        Gizmos.DrawWireCube(center, new Vector3(size*2*16/9,size*2,0));
        Gizmos.DrawWireSphere(center- new Vector3(xOffset, yOffset, 0), 0.5f);

    }
}
