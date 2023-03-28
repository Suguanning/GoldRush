using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashPlat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.current.SquashPlatEnter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.current.SquashPlatExit();
    }
}
