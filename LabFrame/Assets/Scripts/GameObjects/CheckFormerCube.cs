using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFormerCube : MonoBehaviour
{
    public GameObject checkFormerCube;
    //public GameObject[] CubeTouchedTrigger;
    //public GameObject Cube;
    [Header("Question Quad")]
    public List<GameObject> Question1_Quad; 
    public List<GameObject> Question2_Quad; 
    public List<GameObject> Question3_Quad; 
    public List<GameObject> Question4_Quad;
    //public GameObject Quad;

    public bool CheckFormer(Collider Cube)
    {
        bool flag = true;
        print("in");
        Debug.Log("I'm checking");
        Debug.Log(Cube);
       // bool flag = true;
       // this.Cube = GameObject.Find("RedCube(Clone)");
        if (Cube is null)
        {
            throw new ArgumentNullException(nameof(Cube));
        }
        print("fucking bitch");
       /* Collider MyCube;
        MyCube = GameObject.Find("RedCube(Clone)").GetComponent<BoxCollider>();
        Debug.Log(MyCube);*/
        while (Cube == GameObject.Find("RedCube(Clone)").GetComponent<BoxCollider>())
        {
            Debug.Log("in while " + Cube);
            if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == false)
            {
                print("great job!!");
                Cube.GetComponent<Rigidbody>().isKinematic = true;
                Cube.GetComponent<Animator>().enabled = false;
                print("this " + Cube.name + "iskinematic");
                flag = true;
            }
            else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
            {
                Debug.Log("wrong");
                print("put 8 first!!");
                Cube.GetComponent<Animator>().enabled = true;
                print("music");
                flag = false;
            }
            else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == true && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
            {
                print("try it again");
                Cube.GetComponent<Animator>().enabled = true;
                print("you can do it");
                flag = false;
            }
            
        } 
        return flag;
        //StartCoroutine(ActionOne());
        //StartCoroutine(ActionTwo());
        //yield return null;
    }
    /*IEnumerator ActionOne()
    {
        Debug.Log("I'm checking");
        Debug.Log(Cube);
        bool flag = true;
        this.Cube = GameObject.Find("RedCube(Clone)");
        if (Cube is null)
        {
            throw new ArgumentNullException(nameof(Cube));
        }
        print("fucking bitch");
        if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == false)
        {
            print("great job!!");
            this.Cube.GetComponent<Rigidbody>().isKinematic = true;
            this.Cube.GetComponent<Animator>().enabled = false;
            print("this " + this.Cube.name + "iskinematic");
            flag = true;
        }
        else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == false && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
        {
            Debug.Log("wrong");
            print("put 8 first!!");
            this.Cube.GetComponent<Animator>().enabled = true;
            print("music");
            flag = false;

            //print("this is" + Quad);

            //} 
        }
        else if (GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>().isTrigger == true && GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>().isTrigger == true)
        {
            print("try it again");
            this.Cube.GetComponent<Animator>().enabled = true;
            print("you can do it");
            flag = false;
        }
        return flag;
    }*/
}
    /*IEnumerator ActionTwo()
    {
        if (GameObject.Find("Q1Quad0").GetComponent<BoxCollider>().isTrigger == false)
        {
            GameObject Quad = GameObject.Find("Q1Quad1");
            //print("this is" + Quad);
            print("put 7 first!!");
        }
        yield break;
    }*/


