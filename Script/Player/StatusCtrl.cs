using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusCtrl : MonoBehaviour
{

    [Space]
    public string mode = "play";
    private Movement move;
    private Collision coll;
    private CoinRotate rotate;
    [Space]
    [Header("Booleans")]
    public bool isAlive = true;
    public bool isSquashing = false;
    public bool doSq = false;
    public bool doRc = false;
    [Space]
    [Header("Stats")]
    public float health = 100;
    public Vector3 bornPosition;
    public float squashTime = 0.5f;
    public float recoverTime = 3.0f;
    public float squashKeep = 3.0f;
    private int recoverCnt = 0;

    private Transform trans;
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
        GameEvents.current.OnSquashPlatEnter += OnSquashPlatEnter;
        GameEvents.current.OnSquashPlatExit += OnSquashPlatExit;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == "play")
        {
            
        }
        else if(mode == "show")
        {

        }
        if (doSq)
        {
            health -= 10;
            GameEvents.current.SetHealth(health);
            doSq = false;
        }
        if (doRc)
        {
            health += 10;
            GameEvents.current.SetHealth(health);
            doRc = false;
        }
    }
    private void FixedUpdate()
    {
        if (!isSquashing)
        {
            if (recoverCnt * Time.fixedDeltaTime < squashKeep && recoverCnt > -0.5f)
            {
                recoverCnt++;
                
            }else if(recoverCnt * Time.fixedDeltaTime >= squashKeep)
            {
                SquashRecover();
                recoverCnt = -1;
            }
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
        move.enabled = false;
        mode = "show";
    }
    private void OnShowModeExit()
    {
        mode = "play";
        move.enabled = true;
    }
    private void OnDangerPlatEnter()
    {
        health = 0;
        isAlive = false;
        GameEvents.current.SetHealth(0);
    }

    private void OnDangerPlatExit()
    {

    }

    private void OnSquashPlatEnter()
    {
        rotate.autoRotate = false;
        rotate.enabled = false;
        move.rb.velocity = new Vector2(0, 0);
        move.rb.gravityScale = 3;
        move.enabled = false;
        isSquashing = true;
        recoverCnt = 0;
        LeanTween.scaleX(gameObject, 1.7f, squashTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 0.3f, squashTime).setEase(LeanTweenType.easeOutBounce);
    }
  
    private void OnSquashPlatExit()
    {
        move.enabled = true;
        isSquashing = false;
    }
    private void SquashRecover()
    {
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
