using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    
    private void Awake()
    { 
        current = this; 
    }

    // ×¢²áÊÂ¼þ
    public event Action<int> OnObjectMoveTriggerEnter;
    public void ObjectMoveTriggerEnter(int object_id)
    {
        if (OnObjectMoveTriggerEnter != null)
        {
            OnObjectMoveTriggerEnter(object_id);
        }
    }

    public event Action<int> OnObjectBackTriggerEnter;
    public void ObjectBackTriggerEnter(int object_id)
    {
        if (OnObjectBackTriggerEnter != null)
        {
            OnObjectBackTriggerEnter(object_id);
        }
    }

    public event Action OnDangerPlatEnter;
    public void DangerPlatEnter( )
    {
        if (OnDangerPlatEnter != null)
        {
            OnDangerPlatEnter();
        }
    }

    public event Action OnSquashPlatEnter;
    public void SquashPlatEnter()
    {
        if (OnDangerPlatEnter != null)
        {
            OnSquashPlatEnter();
        }
    }

    public event Action OnSquashPlatExit;
    public void SquashPlatExit()
    {
        if (OnSquashPlatExit != null)
        {
            OnSquashPlatExit();
        }
    }

    public event Action<int> OnShowTrigerEnter;
    public void ShowTrigerEnter(int showNum)
    {
        if (OnShowTrigerEnter != null)
        {
            OnShowTrigerEnter(showNum);
        }
    }
    public event Action OnShowTrigerExit;
    public void ShowTrigerExit()
    {
        if (OnShowTrigerExit != null)
        {
            OnShowTrigerExit();
        }
    }

    public event Action<float> OnSetHealth;
    public void SetHealth(float h)
    {
        if(OnSetHealth != null)
        {
            OnSetHealth(h);
        }
    }

    public event Action OnMarkTouchCoin;
    public void MarkTouchCoin() 
    {
        if (OnMarkTouchCoin != null)
        {
            OnMarkTouchCoin();
        }
    }
}
