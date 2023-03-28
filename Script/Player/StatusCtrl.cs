using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusCtrl : MonoBehaviour
{
    public float health = 100;
    public Vector3 bornPosition;
    public string mode = "play";
    public Movement move;
    public Collision coll;
    public CoinRotate rotate;
    public bool isAlive = true;
    public float squashTime = 0.5f;
    public float recoverTime = 3.0f;
    public float squashKeep = 3.0f;
    public bool doSq = false;
    public bool doRc = false;
    private Transform trans;
    private event Action OnSqExit;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        coll = GetComponent<Collision>();
        trans = GetComponent<Transform>();
        rotate = GetComponentInChildren<CoinRotate>();
        LeanTween.init(1800);
        GameEvents.current.OnShowTrigerEnter += OnShowModeEnter;
        GameEvents.current.OnShowTrigerExit += OnShowModeExit;
        GameEvents.current.OnDangerPlatEnter += OnDangerPlatEnter;
        OnSqExit += OnSquashPlatExit;

    }

    // Update is called once per frame
    void Update()
    {
        if(mode == "play")
        {
            move.enabled = true;
        }
        else if(mode == "show")
        {
            move.enabled = false;
        }
        if (doSq)
        {
            OnSquashPlatEnter();
            doSq = false;
        }
        if (doRc)
        {
            OnSquashPlatExit();
            doRc = false;
        }
    }

    private void ResetStatus()
    {
        health = 100;
        isAlive = true;
        trans.position = bornPosition;
    }
    //CallBack functions
    private void OnShowModeEnter(int showNum)
    {
        move.rb.velocity = new Vector2(0, 0);
        mode = "show";
    }
    private void OnShowModeExit()
    {
        mode = "play";
    }
    private void OnDangerPlatEnter()
    {
        health = 0;
        isAlive = false;
    }

    private void OnDangerPlatExit()
    {

    }

    private void OnSquashPlatEnter()
    {
        rotate.autoRotate = false;
        rotate.enabled = false;
        LeanTween.scaleX(gameObject, 1.7f, squashTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 0.3f, squashTime).setEase(LeanTweenType.easeOutBounce);
    }
  
    private void OnSquashPlatExit()
    {
        StartCoroutine(SquashRecover());
    }
    IEnumerator SquashRecover()
    {
        yield return new WaitForSeconds(squashKeep);
        rotate.autoRotate = true;
        rotate.enabled = true;
        LeanTween.scaleX(gameObject, 1, recoverTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 1, recoverTime).setEase(LeanTweenType.easeOutBounce);
    }

    private void OnMovePlatEnter()
    {

    }

    private void OnMovePlatExit()
    {

    }

    private void OnCoinmanEnter()
    {

    }
    private void OnCoinmanExit()
    {

    }
}
