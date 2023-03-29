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
    public float maxStayBackTime;
    public double stayTime;
    public double stayBackTime;
    public bool isBack = true;
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
        if (needTrigger && !arrive && isBack && stayBackTime >= maxStayBackTime)
        {
            LeanTween.move(parentObj, new Vector3(sonX, sonY, 0), moveSpeed).setEase(LeanTweenType.easeOutBounce);
            isBack = false;
            stayBackTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!needTrigger && !arrive && isBack && stayBackTime >= maxStayBackTime) { 
            LeanTween.move(parentObj, new Vector3(sonX, sonY, 0), moveSpeed).setEase(LeanTweenType.easeOutBounce);
            isBack = false;
            stayBackTime = 0;
        }
        if (isBack) stayBackTime += 0.02;

        // ����������λ��
        if (parentObj.transform.position == new Vector3(sonX, sonY, 0)) arrive = true;
        // �ص�������λ��
        if (parentObj.transform.position == new Vector3(parentX, parentY)) isBack = true;
        // ����������λ�ý���ͣ����ʱ
        if (arrive) stayTime += 0.02;
        if (stayTime >= maxStayTime)
        {
            LeanTween.move(parentObj, new Vector3(parentX, parentY, 0), moveSpeed).setEase(LeanTweenType.easeOutBounce);
            stayTime = 0;
            arrive = false;
        }
    }
}
