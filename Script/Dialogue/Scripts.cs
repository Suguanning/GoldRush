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
        convAndAct[0] = new ConvAndAct(4, 0);
        convAndAct[0].AddLine("Mark", "PLAYER! Welcome!");
        convAndAct[0].AddLine("Mark", "Thank you for playing \"Gold Rush\" among the countless games in the real universe!") ;
        convAndAct[0].AddLine("Mark", "I am Mark.I will do my best to serve you!");
        convAndAct[0].AddLine("Mark", "The game object is to collect 100 gold coins to win!");

        convAndAct[1] = new ConvAndAct(10, 0);
        convAndAct[1].AddLine("God of Fools", "These talking gold coins are so cute, I need to find a way to get one!");
        convAndAct[1].AddLine("Gold Coin", "Playing as a gold coin is so boring......");
        convAndAct[1].AddLine("Gold Coin" ,"Mark only cares about players every day.") ;
        convAndAct[1].AddLine("Gold Coin", "I have rust on me for a few days without helping me clean up.");
        convAndAct[1].AddLine("Gold Coin", "We've been chased by Mark and don't even have time to rest.");
        convAndAct[1].AddLine("Gold Coin", "Wish to the god of fools on April Fool's Day ......");
        convAndAct[1].AddLine("Gold Coin", "......can we wish for anything ?") ;
        convAndAct[1].AddLine("Gold Coin", "Make a wish! Mark! Become! Gold Coin!");
        convAndAct[1].AddLine("Gold Coin", "Let Mark also try to play the gold coin, let him know how tired the job is !");
        convAndAct[1].AddLine("God of Fools", "lol");

        convAndAct[2] = new ConvAndAct(2, 0);
        convAndAct[2].AddLine("Mark(Coin)", "What happened?!!I became a coin!!");
        convAndAct[2].AddLine("Gold Coin", "Let's find out where Mark is hiding!");

    }

}
