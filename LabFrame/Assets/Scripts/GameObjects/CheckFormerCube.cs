using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFormerCube : MonoBehaviour
{
    public GameObject checkFormerCube;
    //[Header("Question Quad")]
    //public List<GameObject> Question1_Quad; 
    //public List<GameObject> Question2_Quad; 
    //public List<GameObject> Question3_Quad; 
    //public List<GameObject> Question4_Quad;
    private int i;
    public bool CheckQ1Former(Collider Cube)
    {
        if (Cube is null)
        {
            throw new ArgumentNullException(nameof(Cube));
        }
        Debug.Log(Cube);//RedCube(Clone)

        string cubeName = Cube.name;
        int delStr = cubeName.IndexOf("(Clone)");
        if (delStr >= 0)
        {
            cubeName = cubeName.Remove(delStr);
        }
        print(cubeName + " is checking");
        Collider[] Q1Quad = {
            GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>(),
            GameObject.Find("YellowCuboid(Q1Quad2)").GetComponent<BoxCollider>(),
            GameObject.Find("GreenCuboid(Q1Quad3)").GetComponent<BoxCollider>(),
            GameObject.Find("RedCuboid(Q1Quad4)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCuboid(Q1Quad5)").GetComponent<BoxCollider>(),
            GameObject.Find("YellowCuboid3(Q1Quad6)").GetComponent<BoxCollider>(),
            GameObject.Find("GreenCuboid3(Q1Quad7)").GetComponent<BoxCollider>(),
            GameObject.Find("RedCuboid3(Q1Quad8)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCuboid3(Q1Quad9)").GetComponent<BoxCollider>(),
        };

        //print(Q1Quad[1]);
        //Debug.Log(Q1Quad[i].name);

        bool flag = true;
        Debug.Log("I'm checking");
        print("fucking bitch");
        if (Cube == GameObject.Find("RedCube(Clone)").GetComponent<BoxCollider>()) { i = 0; }
        if (Cube == GameObject.Find("BlueCube(Clone)").GetComponent<BoxCollider>()) { i = 1; }
        if (Cube == GameObject.Find("YellowCuboid(Clone)").GetComponent<BoxCollider>()) { i = 2; }
        if (Cube == GameObject.Find("GreenCuboid(Clone)").GetComponent<BoxCollider>()) { i = 3; }
        if (Cube == GameObject.Find("RedCuboid(Clone)").GetComponent<BoxCollider>()) { i = 4; }
        if (Cube == GameObject.Find("BlueCuboid(Clone)").GetComponent<BoxCollider>()) { i = 5; }
        if (Cube == GameObject.Find("YellowCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 6; }
        if (Cube == GameObject.Find("GreenCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 7; }
        if (Cube == GameObject.Find("RedCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 8; }
        if (Cube == GameObject.Find("BlueCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 9; }

        while (true)
        {
            Debug.Log("in while " + Cube);
            Debug.Log(Q1Quad[i]);
            if (i == 9)
            {
                print("good job!!");
                Cube.GetComponent<Rigidbody>().isKinematic = true;
                Cube.GetComponent<Animator>().enabled = false;
                print("this " + Cube.name + "iskinematic");
                flag = true;
                break;
            }
            else if (Q1Quad[i].isTrigger == false && Q1Quad[i + 1].isTrigger == false)
            {
                print("great job!!");
                Cube.GetComponent<Rigidbody>().isKinematic = true;
                Cube.GetComponent<Animator>().enabled = false;
                print("this " + Cube.name + "iskinematic");
                flag = true;
                break;
            }
            else if (Q1Quad[i].isTrigger == false && Q1Quad[i + 1].isTrigger == true)
            {
                Debug.Log("wrong");
                print("put former first!!");
                Cube.GetComponent<Animator>().enabled = true;
                print("music");
                //print(Cube.transform.position);
                //Cube.transform.SetPositionAndRotation(new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0)), Quaternion.Euler(new Vector3(0, 0, 0)));
                //print("New" + Cube.transform.position);
                //Cube.GetComponent<Animator>().enabled = false;
                flag = false;
                break;
            }
            else if (Q1Quad[i].isTrigger == true && Q1Quad[i + 1].isTrigger == true)
            {
                print("try it again");
                Cube.GetComponent<Animator>().enabled = true;
                print("you can do it");
                flag = false;
                break;
            }
            print("out of while loop");
            break;
        }
        return flag;
        //StartCoroutine(ActionOne());
        //StartCoroutine(ActionTwo());
        //yield return null;
    }
}
   


