using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopRedrawCube : MonoBehaviour
{
    //public GameObject cube;
    public GameObject[] Cube;
    public Button myStopButton;

    private void Start()
    {
        myStopButton.onClick.AddListener(stopRedraw);
    }

    public void stopRedraw()
    {
        print("stopping");
        if (myStopButton.interactable == false)
        {
            //GetComponent<CubeDisappear>().enabled = false;
            //GetComponent<DragCube>().enabled = false;
            Cube = GameObject.FindGameObjectsWithTag("cube");
            foreach (GameObject cube in Cube)
            {
                cube.GetComponent<DragCube>().dragDisabled = false;
            }
            print(this.name + " stopped");
        }
    }
}
