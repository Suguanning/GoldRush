using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdowShow : MonoBehaviour
{
    private bool isShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            LeanTween.moveLocalX(gameObject, -454.3f, 0.2f);//.setEase(LeanTweenType.easeOutBounce);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LeanTween.moveLocalX(gameObject, -523, 0.2f);//.setEase(LeanTweenType.easeOutBounce);
        }
    }

}
