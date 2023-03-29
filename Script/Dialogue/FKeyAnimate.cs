using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKeyAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public float period = 0.2f;
    public float normalScale = 0.6f;
    public float changeScale = 0.4f;
    public KeyCode KeyCode = KeyCode.F;
    private float timeCnt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode))
        {
            LeanTween.scaleY(gameObject, changeScale, period).setEase(LeanTweenType.easeOutBounce);
            LeanTween.scaleX(gameObject, changeScale, period).setEase(LeanTweenType.easeOutBounce);
        }
        else if (Input.GetKeyUp(KeyCode))
        {
            LeanTween.scaleY(gameObject, normalScale, period).setEase(LeanTweenType.easeOutBounce);
            LeanTween.scaleX(gameObject, normalScale, period).setEase(LeanTweenType.easeOutBounce);
        }
    }
}
