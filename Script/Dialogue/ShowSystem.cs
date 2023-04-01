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
#if     UNITY_EDITOR //编辑器中退出游戏
            UnityEditor.EditorApplication.isPlaying = false;
#else //应用程序中退出游戏
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
