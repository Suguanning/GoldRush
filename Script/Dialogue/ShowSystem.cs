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
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameEvents.current.ShowTrigerEnter(1);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
#if     UNITY_EDITOR //�༭�����˳���Ϸ
            UnityEditor.EditorApplication.isPlaying = false;
#else //Ӧ�ó������˳���Ϸ
            UnityEngine.Application.Quit();
#endif
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
