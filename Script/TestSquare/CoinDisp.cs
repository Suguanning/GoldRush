using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisp : MonoBehaviour
{
    public int num;
    void Start()
    {
        GameEvents.current.OnShowTrigerEnter += OnShowEnter;
        GameEvents.current.OnShowTrigerExit += OnShowEnd;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnShowEnter(int showNum)
    {
        if (showNum == 3)
        {
            num = 3;
            gameObject.SetActive(false);
        }
    }
    void OnShowEnd()
    {

    }
}
