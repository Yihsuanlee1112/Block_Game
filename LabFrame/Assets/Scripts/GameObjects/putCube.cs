using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : MonoBehaviour
{
    //public GameObject Cube;
    //private Instantiate_Cube Cube;
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
        print("hit");
        string cubeName = answerCube.name;
        int foundS1 = cubeName.IndexOf("(Clone)");
        print(cubeName);
        if (foundS1>= 0)
        {
            cubeName = cubeName.Remove(foundS1);
            print(cubeName);
        }

        print(gameObject.name);
        //Cube = answerCube.gameObject.GetComponent<Color>();
        if (gameObject.name == cubeName)
        {
            print("hit again");
            answerCube.transform.parent = gameObject.transform;
            print("stick");
            //answerCube.transform.position = new Vector3(-0.24f, 1.4f, 4.11f);
            //answerCube.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }
    }
}
