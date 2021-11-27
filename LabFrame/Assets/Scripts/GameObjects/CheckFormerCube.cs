using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFormerCube : MonoBehaviour
{
    public GameObject[] CubeTouchedTrigger;
    public GameObject[] Question; 

    void Start()
    {
        print("BONJUOR");
        while(GetComponent<Instantiate_Cube>().Cubes[9].GetComponent<Rigidbody>().isKinematic == true)
        {
            if(GetComponent<Instantiate_Cube>().Cubes[8].GetComponent<Rigidbody>().isKinematic == false)
            {
                GetComponent<Instantiate_Cube>().Cubes[9].GetComponent<Animator>().enabled = true;
            }
        }
    }
   
}
