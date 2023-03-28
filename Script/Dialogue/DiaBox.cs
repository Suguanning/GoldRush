using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiaBox : MonoBehaviour
{
    // Start is called before the first frame update
    private Image DiaBoxImage;
    public Image Mark;
    public Image CoinMark;
    public Image Coin;
    //public Image Joker;
    public Scripts scp;
    public Text character;
    public Text lines;
    public Image Fkey;
    public bool enable = false;
    public int showNum;
    public int convIndex;
    public int convLen;
    void Start()
    {
        scp = GetComponent<Scripts>();
        DiaBoxImage = GetComponent<Image>();
        //Í·Ïñ
        Mark.enabled = false;
        CoinMark.enabled = false;
        Coin.enabled = false;
        //Joker.enable = true;
        Fkey.enabled = false;

        character.enabled = false;
        lines.enabled = false;
        DiaBoxImage.enabled = false;
        
        GameEvents.current.OnShowTrigerEnter += OnShowNumRecieve;
        
        //SetDiaBoxEnable(false);
    }

    // Update is called once per frame
    void Update()
    {
        string spkName;
        
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                convIndex++;
                if(convIndex < convLen)
                {
                    SetNameAndLine(scp.convAndAct[showNum - 1].conv[convIndex].speaker, scp.convAndAct[showNum - 1].conv[convIndex].lines);
                    spkName = scp.convAndAct[showNum - 1].conv[convIndex].speaker;
                    SetIcon(spkName);
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
        character.enabled = enable;
        lines.enabled = enable;
        DiaBoxImage.enabled = enable;
        Fkey.enabled = enable;
    }
    public void SetIcon(string spkName)
    {
        if (spkName == "Mark")
        {
            Mark.enabled = true;
            CoinMark.enabled = false;
            Coin.enabled = false;
            //Joker.enable = false;
        }
        else if (spkName == "CoinMark")
        {
            Mark.enabled = false;
            CoinMark.enabled = true;
            Coin.enabled = false;
            //Joker.enable = false;
        }
        else if (spkName == "Coin")
        {
            Mark.enabled = false;
            CoinMark.enabled = false;
            Coin.enabled = true;
            //Joker.enable = false;
        }
        else if (spkName == "Joker")
        {
            Mark.enabled = false;
            CoinMark.enabled = false;
            Coin.enabled = false;
            //Joker.enable = true;
        }
    }
    public void OnShowNumRecieve(int num)
    {
        enable = true;
        SetDiaBoxEnable(true);
        showNum = num;
        convIndex = 0;
        Debug.Log(scp.convAndAct[showNum - 1].conv[0].speaker);
        SetNameAndLine(scp.convAndAct[showNum - 1].conv[0].speaker, scp.convAndAct[showNum - 1].conv[0].lines);
        SetIcon(scp.convAndAct[showNum - 1].conv[0].speaker);
        convLen = scp.convAndAct[num - 1].convLen;

    }
    public void ShowEnd()
    {
        enable = false;
        SetDiaBoxEnable(false);
        showNum = 0;
        convIndex = 0;
        GameEvents.current.ShowTrigerExit();
    }
}
