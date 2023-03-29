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
        // 开始时隐藏触发器
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // 记录父物体位置
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

        // 到达子物体位置
        if (parentObj.transform.position == new Vector3(sonX, sonY, 0)) arrive = true;
        // 回到父物体位置
        if (parentObj.transform.position == new Vector3(parentX, parentY)) isBack = true;
        // 到达子物体位置进行停留计时
        if (arrive) stayTime += 0.02;
        if (stayTime >= maxStayTime)
        {
            LeanTween.move(parentObj, new Vector3(parentX, parentY, 0), moveSpeed).setEase(LeanTweenType.easeOutBounce);
            stayTime = 0;
            arrive = false;
        }
    }
}
