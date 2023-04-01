using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTriger : MonoBehaviour
{
    public int showNum;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.current.ShowTrigerEnter(showNum);
        }
    }
}
