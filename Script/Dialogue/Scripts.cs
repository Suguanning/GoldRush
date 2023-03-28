using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
   public struct Dialogue
    {
        public string speaker;//说话人
        public string lines;  //台词
        public void set(string spk,string l)
        {
            speaker = spk;
            lines = l;
        }
    }
    public class ConvAndAct
    {
        private int index = 0;
        public int convLen;
        public int actLen;
        public Dialogue[] conv;
        public ConvAndAct(int cLen,int actionLen)
        {
            conv = new Dialogue[cLen];
            convLen = cLen;
        }
        public void AddLine(string n,string l)
        {
            if(index >= convLen)
            {
                Debug.Log("conversation too long");
                return;
            }
            conv[index].set(n, l);
            index++;
        }
    }
    public ConvAndAct[] convAndAct = new ConvAndAct[10];
    // Start is called before the first frame update
    void Start()
    {
        convAndAct[0] = new ConvAndAct(3, 0);
        convAndAct[0].AddLine("Mark", "Welcome To My Game");
        convAndAct[0].AddLine("Mark", "Please help me!");
        convAndAct[0].AddLine("Mark","Thank you very much!");
    }

}
