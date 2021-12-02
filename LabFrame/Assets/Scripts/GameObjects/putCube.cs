using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : MonoBehaviour
{
    //public GameObject Cube;
    //public Rigidbody rigidbody;
    //private DragCube isDragging;
    //private CubeDisappear cubeDisappear;
    //public GameObject[] Q1_Cube;
    //public GameObject Quad0;
    //public GameObject Cube;
    //public CheckFormerCube checkFormer;
    public CheckFormerCube checkFormer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider answerCube)
    {
        //Get Cube name without "(Clone)"
        string cubeName = answerCube.name;
        int delStr = cubeName.IndexOf("(Clone)");
        print(cubeName + "I took");
        if (delStr >= 0)
        {
            cubeName = cubeName.Remove(delStr);
        }
        print("put on..." + gameObject.name);
        //CheckformerCube();

        //Cube = answerCube.gameObject.GetComponent<Color>();

        if (gameObject.name == cubeName)
        {
            print("stick");
            checkFormer.CheckFormer(answerCube);
            //CheckformerCube(answerCube);
            Debug.Log(answerCube);
            //GetComponent<CheckFormerCube>();
            answerCube.transform.localScale = gameObject.transform.localScale;
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.parent = gameObject.transform;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);//相對於父物件的位置
            
            //print(GetComponent<QuadTriggerDisabled>().Quad);
            /* print(gameObject.GetComponent<Transform>().position);
             print(answerCube.name+answerCube.transform.position);
             print(answerCube.transform.rotation);
             print(gameObject.transform.rotation);
             print(answerCube.transform.localScale);
             print(gameObject.transform.localScale);*/
           /* answerCube.GetComponent<Rigidbody>().isKinematic = true;
            answerCube.GetComponent<Animator>().enabled = false;
            print("this " + answerCube.name + "iskinematic");
*/
            //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            //answerCube.GetComponent<DragCube>().enabled = false;

        }
        /*else if(gameObject.name != cubeName)
        {
            answerCube.transform.parent = null;
            //answerCube.GetComponent<Rigidbody>().isKinematic = true;
            //print("this wrong" + answerCube.name + "iskinematic");
            answerCube.GetComponent<Animator>().enabled=true;
            Debug.Log("play animator");*/
        
           
    }
    public bool CheckformerCube(Collider Cube)
    {
        Debug.Log("I'm checking");
        Debug.Log(Cube);
        bool flag = true;
       // this.Cube = GameObject.Find("RedCube(Clone)");
        if (Cube is null)
        {
            throw new ArgumentNullException(nameof(Cube));
        }
        print("fucking bitch");
        if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == false)
        {
            print("great job!!");
            Cube.GetComponent<Rigidbody>().isKinematic = true;
            Cube.GetComponent<Animator>().enabled = false;
            print("this " + Cube.name + "iskinematic");
            flag = true ;
        }
        else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
        {
            Debug.Log("wrong");
            print("put 8 first!!");
            Cube.GetComponent<Animator>().enabled = true;
            print("music");
            flag = false;

            //print("this is" + Quad);
            
            //} 
        }
        else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == true && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
        {
            print("try it again");
            Cube.GetComponent<Animator>().enabled = true;
            print("you can do it");
            flag = false;
        }
        return flag;
    }
    //    Cubes[Cubes.Length - 1])
}

