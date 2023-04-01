using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(tar.transform.position.x, tar.transform.position.y,transform.position.z) ;
    }
}
