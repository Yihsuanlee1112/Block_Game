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
    public GameObject[] Q1_Cube;
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
        print(cubeName);
        if (delStr >= 0)
        {
            cubeName = cubeName.Remove(delStr);
        }
        print(gameObject.name);

        //Cube = answerCube.gameObject.GetComponent<Color>();

        if (gameObject.name == cubeName)
        {
            print("stick");
            GetComponent<CheckFormerCube>();
            answerCube.transform.localScale = gameObject.transform.localScale;
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.parent = gameObject.transform;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);//相對於父物件的位置
            //CheckformerCube();
            answerCube.GetComponent<Animator>().enabled = false;
            //print("hit");
            print(gameObject.GetComponent<Transform>().position);
            //print(gameObject.GetComponent<Transform>().position + new Vector3(0.5f, 0.5f, -0.5f));
            print(answerCube.name+answerCube.transform.position);
            print(answerCube.transform.rotation);
            print(gameObject.transform.rotation);
            print(answerCube.transform.localScale);
            print(gameObject.transform.localScale);
            answerCube.GetComponent<Rigidbody>().isKinematic = true;
            //print("this " + answerCube.name + "iskinematic");
            //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            //answerCube.GetComponent<DragCube>().enabled = false;
            
        }
        else if(gameObject.name != cubeName)
        {
            answerCube.transform.parent = null;
            //answerCube.GetComponent<Rigidbody>().isKinematic = true;
            //print("this wrong" + answerCube.name + "iskinematic");
            answerCube.GetComponent<Animator>().enabled=true;
            if(answerCube.GetComponent<Animator>().enabled == true)
            {
                if (answerCube.tag == "cube")
                {
                    print("this is a cube");
                    answerCube.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (answerCube.tag == "cuboid")
                {
                    print("this is a cuboid");
                    answerCube.transform.localScale = new Vector3(2, 1, 1);
                }
                else if (answerCube.tag == "cuboid3")
                {
                    print("this is a cuboid3");
                    answerCube.transform.localScale = new Vector3(3, 1, 1);
                }
                if (answerCube.tag == "cube2")
                {
                    print("this is a cube2");
                    answerCube.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            
        }   
    }
    //    Cubes[Cubes.Length - 1])
}

