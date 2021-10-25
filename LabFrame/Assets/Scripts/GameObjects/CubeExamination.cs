using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeExamination : MonoBehaviour
{
    public GameObject[] myCubes;
    public List<Vector3> CubePosList;
    public List<Color> CubeColorList;
    public Button myStopButton;
    //public Color CubeColor;
    /*
     * Shapes shapes;
    enum Shapes
    {
        Cube, Cuboid, triangle, Cylinder
    }
    */

    
    public void ListCubes()
    {
        myStopButton = GetComponent<Button>();
        myCubes = GameObject.FindGameObjectsWithTag("cube");// 所有 tag 為 cube 的物件，都會被抓出來存到變數(陣列) myCubes` 中
        foreach (GameObject cube in myCubes)
        {   
            Color cubeColor = cube.gameObject.GetComponent<MeshRenderer>().material.color;
            CubePosList.Add(cube.transform.position * 1000);//add the transform in the list
            //print("listing");
            CubeColorList.Add(cubeColor);
        }//列出所有積木的座標
       
       
    }

    //檢查積木數量
    public void ExamineCubesNum()
    {
        if (myCubes.Length < 3)
            print("Fail");
        else
            print("good");
    }

    //檢查積木顏色
    public int ExamineCubeColor(int i)
    {
        if (CubeColorList[i] == Color.blue)
        {
            print("Correct color");
            return 1;
        }
        if (CubeColorList[i] == Color.red)
        {
            return 2;
        }
        if (CubeColorList[i] == Color.green)
        {
            return 3;
        }
        else
        {
            print("wrong color");
            return 0;
        }
    }

    //檢查積木形狀
      public int ExamineCubeShape(int i)
    {
        print("check shape");
        Vector3 CubeScale = new Vector3(1, 1, 1);
        Vector3 CuboidScale = new Vector3(2, 1, 1);
        if (myCubes[i].transform.localScale == CubeScale)
        {
            print("A cube");
            return 1;
        }
        if (myCubes[i].transform.localScale == CuboidScale)
        {
            print("A cuboid");
            return 2;
        }
        else
        {
            return 0;
        }
    }

    //檢查積木座標(一對多)
    //public int ExamineCubeCoordinate(int i)
    //{
        
    //}
    public void CheckIfCorrect()
    {
        for(int i= 0; i<myCubes.Length; i++)
        {
            int rnt1 = ExamineCubeColor(i);
            int rnt2 = ExamineCubeShape(i);
            if(rnt1 == 1 && rnt2 == 1)
            {
                print("congrats its blue cube");
            }
            if (rnt1 == 2 && rnt2 == 1)
            {
                print("congrats its red cube");
            }
        }
    }


    //使Stop不能按
    public void ClickStopButton()
    {
        myStopButton.interactable = false;
        if(myStopButton.interactable == false)
        {
            print("disabled");
        }
    }


}
