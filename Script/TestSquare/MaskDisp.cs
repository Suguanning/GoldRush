using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDisp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnMarkToCoin += MarkToCoin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MarkToCoin()
    {
        gameObject.SetActive(false);
    }
}
