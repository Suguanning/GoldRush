using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinmanShow : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        GameEvents.current.OnMarkToCoin += MarkToCoin;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MarkToCoin()
    {
        gameObject.SetActive(true);
    }

}
