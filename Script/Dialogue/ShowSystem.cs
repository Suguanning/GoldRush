using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSystem : MonoBehaviour
{

    public DiaBox diaBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameEvents.current.ShowTrigerEnter(1);
        }
    }

    void RunScript(int sceneNum, int len)
    {
        if(sceneNum == 1)
        {
        }
    }
    void OnShowNumRecieve(int num)
    {

    }
}
