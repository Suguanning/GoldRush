using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Movement target;
    public float xOffset;
    public float yOffset;
    public float followSpeed = 1;
    private Rigidbody2D Rb2D;
    public float shakeScale = 1.0f;
    public bool shakeTriger = false;
    public int shakeCnt = 0;
    public int shakeFrame = 30;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = transform.position.x - target.transform.position.x;
        yOffset = transform.position.y - target.transform.position.y;
        Rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x, y, z;
        Vector2 shake = new Vector2(0, 0);
        if (shakeTriger)
        {
            float rand, rand2;
            rand = Random.value - 0.5f;
            rand2 = Random.value - 0.5f;
            shake = new Vector2(rand * shakeScale, rand2 * shakeScale);
            shakeCnt++;
            if (shakeCnt >= shakeFrame)
            {
                shakeCnt = 0;
                shakeTriger = false;
                shake = new Vector2(0,0);
            }
        }

        x = target.transform.position.x;
        y = target.transform.position.y;
        Rb2D.position = Vector2.Lerp(Rb2D.position,new Vector2(x+xOffset,y+yOffset), followSpeed * Time.deltaTime)+shake;

    }
}