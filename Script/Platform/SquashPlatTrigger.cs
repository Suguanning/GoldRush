using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashPlatTrigger : MonoBehaviour
{
    public bool needTrigger;
    private float parentX;
    private float parentY;
    private GameObject parentObj;
    private float sonX;
    private float sonY;
    public bool arrive;
    public float maxStayTime;
    public double stayTime;
    public bool isMove;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // ��ʼʱ���ش�����
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // ��¼������λ��
        parentObj = gameObject.transform.parent.gameObject;
        parentX = parentObj.transform.position.x;
        parentY = parentObj.transform.position.y;
        sonX = gameObject.transform.position.x;
        sonY = gameObject.transform.position.y;
        arrive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (needTrigger && !arrive)
        {
            // ����ʱ�����峯�������ƶ�
            LeanTween.move(parentObj, new Vector3(sonX, sonY, 0), moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (!needTrigger && !arrive && !isMove) { 
            LeanTween.move(parentObj, new Vector3(sonX, sonY, 0), moveSpeed);
            isMove = true;
        }

        // ����������λ��
        if (parentObj.transform.position == new Vector3(sonX, sonY, 0)) arrive = true;
        // �ص�������λ��
        if (parentObj.transform.position == new Vector3(parentX, parentY)) isMove = false;
        // ����������λ�ý���ͣ����ʱ
        if (arrive) stayTime += 0.02;
        if (stayTime >= maxStayTime)
        {
            LeanTween.move(parentObj, new Vector3(parentX, parentY, 0), moveSpeed);
            stayTime = 0;
            arrive = false;
        }
    }
}
