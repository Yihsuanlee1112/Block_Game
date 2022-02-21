using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube" && !PlayerEntity._take && !other.GetComponent<BlockEntity>()._isChose)
        {
           if (!BLockGameTask._playerRound)
            {
               Debug.Log("Wrong Action");
                GameEventCenter.DispatchEvent("NPCRemind");
            }
           Debug.Log("Catch " + other.name);

            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.SetParent(gameObject.transform);
            PlayerEntity._take = true;

            Debug.Log("follow hand");
            Debug.Log(gameObject.name);
            Debug.Log(other.gameObject.name);

        } 
     
        else if (other.gameObject.tag == "q" && PlayerEntity._take)
        {
            Debug.Log("Put toAns");
            var parent = GameObject.Find("Question(Clone)");
            //var parent = GameObject.FindGameObjectWithTag("QuestionArea");
            Debug.Log(parent);
            //var cube = gameObject.transform.GetChild(5).gameObject.GetComponent<BlockEntity>();//hand底下的第6個
            var cube = gameObject.transform.GetChild(0).gameObject.GetComponent<BlockEntity>();//hand底下的第五個
            Debug.Log(cube);
            cube.GetComponent<Rigidbody>().useGravity = true;
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            cube.transform.SetParent(parent.transform);
            GameEventCenter.DispatchEvent("cubeAns", cube);
            BLockGameTask._playerRound = false;
            PlayerEntity._take = false;
        }
    }

 }
    
