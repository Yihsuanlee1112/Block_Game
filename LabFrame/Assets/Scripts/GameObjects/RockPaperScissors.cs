using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour
{
    Vector3 position;
    //Button myRPSButton;
    public List<GameObject> rockPaperScissors;
    public List<GameObject> RPS;
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
       // RPS_Animator.enabled = true;
        position = new Vector3(0, 10, 0);
        RPS.Add(Instantiate(rockPaperScissors[0], position, Quaternion.identity));
        
        position = new Vector3(-5, 10, 0);
        RPS.Add(Instantiate(rockPaperScissors[1], position, Quaternion.identity)); 
        
        position = new Vector3(5, 10, 0);
        RPS.Add(Instantiate(rockPaperScissors[2], position, Quaternion.identity));

        position = new Vector3(0, 5, 0);
        RPS.Add(Instantiate(rockPaperScissors[3], position, Quaternion.identity));

        //RPS_Animator = Resources.Load<Animator>("Animation/RockPaperScissors");
        RPS_Animator.SetTrigger("RPS");
        Debug.Log(RPS_Animator);
        //RPS_Animator.SetTrigger("Idle");
        //RPS_Animator.SetBool("StartRPS", true);

        //myRPSButton.interactable = false;

    }
   

}
