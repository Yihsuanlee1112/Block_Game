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

    private void OnTriggerEnter(Collider other)//other=>cube
    {
        
        if (other.gameObject.tag == "cube" && !PlayerEntity._take && !other.GetComponent<BlockEntity>()._isChose)
        {
            
            if (!BLockGameTask._playerRound)
            {
               Debug.Log("Wrong Action");
               GameEventCenter.DispatchEvent("NPCRemind");
            }
            //else if(other)
            
            Debug.Log("Catch " + other.name);
            
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.SetParent(gameObject.transform);
            PlayerEntity._take = true;
            //GameEventCenter.DispatchEvent("CheckIfRightCube");

            Debug.Log("follow hand");
            Debug.Log(gameObject.name);
            Debug.Log(other.gameObject.name);

            //int MyCube = GetComponent<MainSceneRes>().Cubes.IndexOf(other.GetComponent<BlockEntity>());
        
            //Debug.Log(MyCube);
        } 
     
        else if (other.gameObject.tag == "q" && PlayerEntity._take)
        {
            Debug.Log("Put toAns");
            var parent = GameObject.Find("Answer");
            //var parent = GameObject.FindGameObjectWithTag("QuestionArea");
            Debug.Log(parent);
            //var cube = gameObject.transform.GetChild(5).gameObject.GetComponent<BlockEntity>();//hand底下的第6個
            var cube = gameObject.transform.GetChild(0).gameObject.GetComponent<BlockEntity>();//FakeHand
            Debug.Log(cube);
            cube.GetComponent<Rigidbody>().useGravity = true;
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            cube.transform.SetParent(parent.transform);
            GameEventCenter.DispatchEvent("CubeAns", cube);
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(parent.transform.position);
            Debug.Log(cube.transform.position);


            BLockGameTask._playerRound = false;
            PlayerEntity._take = false;
        }
    }
    //public bool CheckIfFormerCubeIsChoosed(Collider Cube)
    //{
    //    bool flag = true;
    //    var parent = GameObject.Find("Question(Clone)");
    //    PlayerEntity._take = false;
    //    var myCube = GetComponent<MainSceneRes>().Q1_cube.IndexOf(Cube.GetComponent<BlockEntity>());
    //    Debug.Log(myCube+"hahahahaha");
    //    Cube.gameObject.transform.parent = null;
    //    Debug.Log("Wrong Cube");
    //    GameEventCenter.DispatchEvent("NPCRemind");

    //    return flag;
    //}

 }
    
