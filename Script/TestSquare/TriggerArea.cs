using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int object_id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.current.ObjectMoveTriggerEnter(object_id);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.current.ObjectBackTriggerEnter(object_id);
    }
}
