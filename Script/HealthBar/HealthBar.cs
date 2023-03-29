using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float minScale = 1;
    public float maxScale = 2;
    public float moveTime = 0.3f;
    public float originX = -310;
    public RectTransform rec;
    void Start()
    {
        health = 100;
        GameEvents.current.OnSetHealth += OnSetHealth;
        rec = GetComponent<RectTransform>();
        //originX = rec.localPosition.x;
        OnSetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnSetHealth(health);
        }
    }

    private void OnSetHealth(float h)
    {

        health = h;
        LeanTween.scaleX(gameObject, h / 100 * (maxScale - minScale) + minScale, moveTime).setEase(LeanTweenType.easeOutSine);
        //Debug.Log(rec.sizeDelta.x);
        LeanTween.moveLocalX(gameObject,  h / 100 * (maxScale - minScale)  * 0.5f * rec.sizeDelta.x+originX, moveTime).setEase(LeanTweenType.easeOutSine);
        //LeanTween.
    }

}
