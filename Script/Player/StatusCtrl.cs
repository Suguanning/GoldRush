using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCtrl : MonoBehaviour
{
    public float health = 100;
    public Vector3 bornPosition;
    public string mode = "play";
    public Movement move;
    public Collision coll;

    public bool isAlive = true;

    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        coll = GetComponent<Collision>();
        trans = GetComponent<Transform>();
        GameEvents.current.OnShowTrigerEnter += OnShowModeEnter;
        GameEvents.current.OnShowTrigerExit += OnShowModeExit;
        GameEvents.current.OnDangerPlatEnter += OnDangerPlatEnter;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == "play")
        {
            move.enabled = true;
        }else if(mode == "show")
        {
            move.enabled = false;
        }

    }

    private void Reset()
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

    }
    private void OnSquashPlatExit()
    {

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
