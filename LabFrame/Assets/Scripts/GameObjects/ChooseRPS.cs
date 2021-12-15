using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRPS : MonoBehaviour
{
    //GameObject[] RPS;
    //public Animator[] RPS = new Animator[3];
    public Button Rock_Button;
    public Button Paper_Button;
    public Button Scissors_Button;
    GameObject G1;
    GameObject G2;
    GameObject G3;
    //public Animator RPS_Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        G1 = GameObject.Find("RockPaperScissorsG1(Clone)");
        G2 = GameObject.Find("RockPaperScissorsG2(Clone)");
        G3 = GameObject.Find("RockPaperScissorsG3(Clone)");
        Rock_Button.onClick.AddListener(chooseRock);
        Paper_Button.onClick.AddListener(choosePaper);
        Scissors_Button.onClick.AddListener(chooseScissors);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void chooseRock()
    {
        Debug.Log(G1);
        Debug.Log(G2);
        Debug.Log(G3);
        print("RRR");

    }
    public void choosePaper()
    {
        Debug.Log(G1);
        Debug.Log(G2);
        Debug.Log(G3);
        print("PPP");
    }
    public void chooseScissors()
    {
        Debug.Log(G1);
        Debug.Log(G2);
        Debug.Log(G3);
        print("SSS");
    }
    public void CloseAnimator()
    {
        G1.GetComponent<Animator>().SetTrigger("Idle");
        G2.GetComponent<Animator>().SetTrigger("Idle");
        G3.GetComponent<Animator>().SetTrigger("Idle");
    }
}
