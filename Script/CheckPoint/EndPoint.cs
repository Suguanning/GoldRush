using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public bool isArrived;
    public int mission;
    public GameObject keyPic;
    public bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        //GameEvents.current.OnMissionFinshed += OnMissionFinished;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isArrived)
        {
            keyPic.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)&&!isFinished)
            {
                GameEvents.current.MissionFinished(mission);
                isFinished = true;
                Debug.Log("Mission Finished!!");
            }
        }
        else
        {
            keyPic.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isArrived = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isArrived = false;
        }
    }
}
