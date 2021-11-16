using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : MonoBehaviour
{
    //public GameObject Cube;
    //public Rigidbody rigidbody;
    private DragCube isDragging;
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
        int foundS1 = cubeName.IndexOf("(Clone)");
        print(cubeName);
        if (foundS1>= 0)
        {
            cubeName = cubeName.Remove(foundS1);
        }
        print(gameObject.name);

        //Cube = answerCube.gameObject.GetComponent<Color>();

        if (gameObject.name == cubeName)
        {
            print("stick");
            //answerCube.transform.position = gameObject.GetComponent<Transform>().position; //+ new Vector3(0.5f, 0.5f, -0.5f);
            answerCube.transform.parent = gameObject.transform;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);//相對於父物件的位置
            print("hit");
            print(gameObject.GetComponent<Transform>().position);
            //print(gameObject.GetComponent<Transform>().position + new Vector3(0.5f, 0.5f, -0.5f));
            print(answerCube.name+answerCube.transform.position);
            answerCube.GetComponent<Rigidbody>().isKinematic = true;
            print("this " + answerCube.name + "iskinematic");
            //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            //answerCube.GetComponent<DragCube>().enabled = false;
        }
        else if(gameObject.name != cubeName)
        {
            answerCube.transform.parent = null;
            answerCube.GetComponent<Rigidbody>().isKinematic = false;
        }   
    }
}

