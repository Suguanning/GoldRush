using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerPlat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1111");
        if (collision.gameObject.CompareTag("Player")) 
        GameEvents.current.DangerPlatEnter();
    }

}
