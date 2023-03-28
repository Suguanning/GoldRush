using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSystem : MonoBehaviour
{

    public DiaBox diaBox;
    // Start is called before the first frame update
    void Start()
    {
        diaBox.OnShowNumRecieve(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
