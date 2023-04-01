using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnDisp : MonoBehaviour
{
    public bool showDis;
    public bool Onbegin;
    public int showNum;
    public int num0;
    public SpriteRenderer sp;
    public GameObject tg;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnShowTrigerEnter += OnShow;
        GameEvents.current.OnShowTrigerExit += OnEnd;
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnShow(int num)
    {
        num0 = num;
        if(num == showNum)
        {
            if (Onbegin)
            {
                 setImage(showDis);
            }

        }
    }
    void OnEnd()
    {
        if (num0 == showNum)
        {
            if (!Onbegin)
            {
                setImage(showDis);
            }

        }
    }
    void setImage(bool enable)
    {
        if (sp != null)
        {
            sp.enabled = enable;
        }
        else
        {
            tg.SetActive(enable);
        }
    }
}
