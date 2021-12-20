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
    public void PlayRPS()
    {
        //RPS_Animator
        position = new Vector3(0, 10, 0);
        //RPS.Add(Instantiate(rockPaperScissors[0], position, Quaternion.identity));
        Instantiate(rockPaperScissors[0], position, Quaternion.identity);

        position = new Vector3(-5, 10, 0);
        //RPS.Add(Instantiate(rockPaperScissors[1], position, Quaternion.identity));
        Instantiate(rockPaperScissors[1], position, Quaternion.identity);

        position = new Vector3(5, 10, 0);
        //RPS.Add(Instantiate(rockPaperScissors[2], position, Quaternion.identity));
        Instantiate(rockPaperScissors[2], position, Quaternion.identity); 

        //choose
        position = new Vector3(0, 5, 0);
        //RPS.Add(Instantiate(rockPaperScissors[3], position, Quaternion.identity));
        Instantiate(rockPaperScissors[3], position, Quaternion.identity);
        //RPS_Animator = Resources.Load<Animator>("Animation/RockPaperScissors");
        RPS_Animator.SetTrigger("RPS");
        Debug.Log(RPS_Animator);
        //RPS_Animator.SetTrigger("Idle");
        //RPS_Animator.SetBool("StartRPS", true);

        //myRPSButton.interactable = false;

    }
    public void ShowRockResult()
    {
        
        //Rock
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_0");

        //Paper
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_1");
        
        //Scissors
        //Result = Resources.Load<Sprite>("Animation/RockPaperScissors/RockPaperScissors_2");

        position = new Vector3(0, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.identity);
        Debug.Log(Result);

        
        position = new Vector3(-5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.identity);
        Debug.Log(Result);

        
        position = new Vector3(5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[0], position, Quaternion.identity);
        Debug.Log(Result);
    }
    public void ShowPaperResult()
    {
        position = new Vector3(0, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.identity);
        Debug.Log(Result);

        position = new Vector3(-5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.identity);
        Debug.Log(Result);

        position = new Vector3(5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[1], position, Quaternion.identity);
        Debug.Log(Result);
    }
     public void ShowScissorsResult()
    {
        position = new Vector3(0, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.identity);
        Debug.Log(Result);

        position = new Vector3(-5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.identity);
        Debug.Log(Result);

        position = new Vector3(5, 9, 0);
        Result = Instantiate(rockPaperScissorsResult[2], position, Quaternion.identity);
        Debug.Log(Result);
    }

}
