using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkCtrl : MonoBehaviour
{
    private Movement move;
    private int showNum;
    public Sprite CoinMark;
    // Start is called before the first frame update\
    void Start()
    {
        move = GetComponent<Movement>();
        GameEvents.current.OnShowTrigerEnter += OnShowModeEnter;
        GameEvents.current.OnShowTrigerExit += OnShowModeExit;
        GameEvents.current.OnMarkToCoin += OnMarkToCoin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnShowModeEnter(int num)
    {
        move.rb.velocity = new Vector2(0, 0);
        move.enabled = false;
        showNum = num;
        if(num == 3)
        {
            GameEvents.current.MarkToCoin();
        }
    }
    private void OnShowModeExit()
    {
        move.enabled = true;
        if(showNum == 3)
        {
            //GameEvents.current.MarkToCoin();
        }
    }

    private void OnMarkToCoin()
    {
        
        gameObject.SetActive(false);
       
    }
}
