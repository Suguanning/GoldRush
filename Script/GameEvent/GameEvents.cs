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
}
