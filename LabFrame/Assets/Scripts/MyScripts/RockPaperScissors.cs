using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    Vector3 position;
    //Sprite Result;
    GameObject Result;
    //Button myRPSButton;
    public List<GameObject> rockPaperScissors;
    //public List<Sprite> rockPaperScissorsResult;
    public List<GameObject> rockPaperScissorsResult;
    public List<GameObject> RPS;
    //public List<Sprite> RPSResult;
    public List<GameObject> RPSResult;
    public Animator RPS_Animator;
    //GameObject rps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FourPlayerRPS()
    {
        //RPS_Animator
        position = new Vector3((float)-0.1, (float)1.3, (float)1.97);
        //RPS.Add(Instantiate(rockPaperScissors[0], position, Quaternion.identity));
        Instantiate(rockPaperScissors[1], position, Quaternion.Euler(0, 15, 0));

        position = new Vector3((float)2.804, (float)1.3, (float)1.75);
        //RPS.Add(Instantiate(rockPaperScissors[1], position, Quaternion.identity));
        Instantiate(rockPaperScissors[2], position, Quaternion.Euler(0, -15, 0));

        position = new Vector3((float)4.325, (float)1.3, (float)2.82);
        //RPS.Add(Instantiate(rockPaperScissors[2], position, Quaternion.identity));
        Instantiate(rockPaperScissors[3], position, Quaternion.Euler(0, -45, 0)); 

        //choose
        position = new Vector3(0, 5, 0);
        //RPS.Add(Instantiate(rockPaperScissors[3], position, Quaternion.identity));
        Instantiate(rockPaperScissors[5], position, Quaternion.identity);
        //RPS_Animator = Resources.Load<Animator>("Animation/RockPaperScissors");
        RPS_Animator.SetTrigger("RPS");
        Debug.Log(RPS_Animator);
        //RPS_Animator.SetTrigger("Idle");
        //RPS_Animator.SetBool("StartRPS", true);

        //myRPSButton.interactable = false;

    }
    public void TwoPlayerRPS()
    {
        position = new Vector3((float)1.378, (float)1.144, (float)3.468);
        //RPS.Add(Instantiate(rockPaperScissors[2], position, Quaternion.identity));
        Instantiate(rockPaperScissors[0], position, Quaternion.identity);

        //choose
        position = new Vector3(0, 5, 0);
        //RPS.Add(Instantiate(rockPaperScissors[0], position, Quaternion.identity));
        Instantiate(rockPaperScissors[4], position, Quaternion.identity);
    }
    public void FourPlayerShowRockResult()
    {
        
        //Rock
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_0");

        //Paper
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_1");
        
        //Scissors
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_2");

        position = new Vector3((float)-0.1, (float)1.3, (float)2.0);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.Euler(0, 15, 0));
        Debug.Log(Result);

        
        position = new Vector3((float)2.804, (float)1.3, (float)1.8);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.Euler(0, -15, 0));
        Debug.Log(Result);

        
        position = new Vector3((float)4.325, (float)1.3, (float)3.0);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.Euler(0, -45, 0));
        Debug.Log(Result);
    }
    public void FourPlayerShowPaperResult()
    {
        position = new Vector3((float)-0.1, (float)1.3, (float)2.0);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.Euler(0, 15, 0));
        Debug.Log(Result);

        position = new Vector3((float)2.804, (float)1.3, (float)1.8);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.Euler(0, -15, 0));
        Debug.Log(Result);

        position = new Vector3((float)4.325, (float)1.3, (float)3.0);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.Euler(0, -45, 0));
        Debug.Log(Result);
    }
    public void FourPlayerShowScissorsResult()
    {
        position = new Vector3((float)-0.1, (float)1.3, (float)2.0);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.Euler(0, 15, 0));
        Debug.Log(Result);

        position = new Vector3((float)2.804, (float)1.3, (float)1.8);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.Euler(0, -15, 0));
        Debug.Log(Result);

        position = new Vector3((float)4.325, (float)1.3, (float)3.0);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.Euler(0, -45, 0));
        Debug.Log(Result);
    }
    public void TwoPlayerShowRockResult()
    {
        position = new Vector3((float)1.378, (float)1.0, (float)3.6);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.identity);
        Debug.Log(Result);
    }
    public void TwoPlayerShowPaperResult()
    {
        position = new Vector3((float)1.378, (float)1.12, (float)3.6);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.identity);
        Debug.Log(Result);
    }
    public void TwoPlayerShowScissorsResult()
    {
        position = new Vector3((float)1.378, (float)1.12, (float)3.6);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.identity);
        Debug.Log(Result);
    }

}
