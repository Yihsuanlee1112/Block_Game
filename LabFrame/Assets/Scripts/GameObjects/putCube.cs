using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : MonoBehaviour
{
    public CheckFormerCube checkFormer;
    public Instantiate_Cube instantiate;

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

        if (gameObject.name == cubeName)
        {
            print("stick");
            

            Debug.Log(answerCube);
            answerCube.transform.parent = gameObject.transform;
            print(answerCube.transform.parent + " is my father");
            //answerCube.transform.localScale = gameObject.transform.localScale;
            //print(answerCube.transform.localScale);
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);//相對於父物件的位置
            answerCube.transform.parent = null;
            if (instantiate.RandomQuestion == 1) { checkFormer.CheckQ1Former(answerCube); }
        }
        else if (gameObject.name != cubeName)
        {
            
            answerCube.transform.parent = gameObject.transform;
            print(answerCube.transform.parent + " is my father");
            //answerCube.transform.localScale = gameObject.transform.localScale;
            //print(gameObject.transform.localScale);
            //print(answerCube.transform.localScale);
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);
            answerCube.transform.parent = null;
            //answerCube.GetComponent<Rigidbody>().isKinematic = true;
            //print("this wrong" + answerCube.name + "iskinematic");
            answerCube.GetComponent<Animator>().enabled = true;
            Debug.Log("play animator");
            Debug.Log("transform");
            answerCube.transform.SetPositionAndRotation(new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0)), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        //answerCube.transform.SetPositionAndRotation(new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0)), Quaternion.Euler(new Vector3(0, 0, 0)));
        //Debug.Log(answerCube.transform);
        //answerCube.GetComponent<Animator>().enabled = false;
    }
}
    


