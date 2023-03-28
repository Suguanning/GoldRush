using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiaBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Scripts scp;
    public Text character;
    public Text lines;
    public Image icon;
    public bool enable = false;
    public int showNum;
    public int convIndex;
    public int convLen;
    void Start()
    {
        scp = GetComponent<Scripts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                convIndex++;
                if(convIndex < convLen)
                {
                    SetNameAndLine(scp.convAndAct[showNum - 1].conv[convIndex].speaker, scp.convAndAct[showNum - 1].conv[convIndex].lines);
                }
                else
                {
                    ShowEnd();
                }
            }
        }
    }
    public void SetNameAndLine(string n,string l)
    {
        character.text = n;
        lines.text = l;
    }
    public void SetDiaBoxEnable(bool enable)
    {
        gameObject.SetActive(enable);
    }
    public void OnShowNumRecieve(int num)
    {
        enable = true;
        SetDiaBoxEnable(enabled);
        showNum = num;
        SetNameAndLine(scp.convAndAct[showNum - 1].conv[0].speaker, scp.convAndAct[showNum - 1].conv[0].lines);
        convLen = scp.convAndAct[num - 1].convLen;
    }
    public void ShowEnd()
    {
        enable = false;
        SetDiaBoxEnable(false);
        showNum = 0;
    }
}
