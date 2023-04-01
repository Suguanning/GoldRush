using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerShowUp : MonoBehaviour
{
    public Vector2 end ;
    public Vector2 begin;
    // Start is called before the first frame update
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
        if(showNum == 2)
        {
            LeanTween.move(gameObject, end, 0.2f).setEase(LeanTweenType.easeInOutBounce);
        }
    }
    void OnShowEnd()
    {
            LeanTween.move(gameObject, begin, 0.3f);
        gameObject.SetActive(false);
    }


}
