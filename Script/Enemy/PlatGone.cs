using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGone : MonoBehaviour
{
    // Start is called before the first frame update
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
            
        }
    }
    void OnShowEnd()
    {
        if(num == 3)
        {
            Destroy(gameObject);
        }
    }
}
