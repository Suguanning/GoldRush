using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;

    public Movement move;
    public float spinRate = 1.0f;
    void Start()
    {
        transform = GetComponent<Transform>();
 
       // move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = move.rb.velocity.magnitude;
        if (move.facingRight)
        {
            z = -z;
        }
        Vector3 spin = new Vector3(0, 0, z * spinRate);
        transform.Rotate(spin);
        transform.position = move.transform.position;
    }
}
