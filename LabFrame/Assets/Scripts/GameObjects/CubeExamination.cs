using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeExamination : MonoBehaviour
{
    public Instantiate_Cube Elements;
    public GameObject[] myCubes ;
    public List<Vector3> CubePosList;
    public List<Color> CubeColorList;
    public Button myStopButton;
    public static Vector3 CubeScale = new Vector3(1, 1, 1);
    public static Vector3 CuboidScale = new Vector3(2, 1, 1);
    int[] sequence = new int[5] { 21, 31, 23, 12, 13 };

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
    public int ExamineCubeColor(GameObject gameObject)
    {
        
        //if (gameObject.color == Color.blue)
        if(gameObject.GetComponent<MeshRenderer>().material.color == Color.blue)
        {
            print("blue");
            return 1;
        }
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            print("red");
            return 2;
        }
        if (gameObject.GetComponent<MeshRenderer>().material.color == new Color32(0, 255,0, 255))
        {
            print("green");
            return 3;
        }
        else
        {
            print("wrong color");
            return 0;
        }
    }

    //檢查積木形狀
      public int ExamineCubeShape(GameObject gameObject)
    {
        print("check shape");
        if (gameObject.transform.localScale == CuboidScale)
        {
            print("A cube");
            return 10;
        }
        if (gameObject.transform.localScale == CuboidScale)
        {
            print("A cuboid");
            return 20;
        }
        else
        {
            return 0;
        }
    }

    public int ExaminePosition(int i)
    {
        print("check pos");
        if (Elements.Cubes[i])
        {
            print("above");
            return 1;
        }
        if (myCubes[i].transform.localScale == CuboidScale)
        {
            print("right");
            return 2;
        }
        if (myCubes[i].transform.localScale == CuboidScale)
        {
            print("left");
            return 3;
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
        
        //for(int i= 0; i<myCubes.Length; i++)
        //{
        //    int rnt1 = ExamineCubeColor(i);
        //    int rnt2 = ExamineCubeShape(i);

            //cube
         //   if(rnt1 == 1 && rnt2 == 1)
         //   {
         //       print("congrats its blue cube");
         //   }
         //   if (rnt1 == 2 && rnt2 == 1)
         //   {
         //       print("congrats its red cube");
         //   }
         //   if (rnt1 == 3 && rnt2 == 1)
         //   {
         //       print("congrats its green cube");
         //   }

            //cuboid
         //   if (rnt1 == 1 && rnt2 == 2)
         //   {
         //       print("congrats its blue cuboid");
         //   }
         //   if (rnt1 == 2 && rnt2 == 2)
         //   {
         //       print("congrats its red cuboid");
         //   }
         //   if (rnt1 == 2 && rnt2 == 2)
         //   {
         //       print("congrats its green cuboid");
         //   }
        //}
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
