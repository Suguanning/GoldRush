using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 3;
    public float len = 10;
    void Start()
    {
        LeanTween.moveX(gameObject,GetComponent<Transform>().position.x + 10, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LeanTween.moveX(gameObject, GetComponent<Transform>().position.x + len, time);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            LeanTween.moveX(gameObject, GetComponent<Transform>().position.x - len, time);
        }
    }
}
