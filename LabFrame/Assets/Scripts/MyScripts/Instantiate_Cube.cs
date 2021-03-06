using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Cube : GameEntityBase
{
    //public GameObject InstantiateCube; //物件的生成點。
    [Header("Question Prefabs")]
    //[System.NonSerialized]
    public List<GameObject> Question_Prefabs;
    [Header("Cube Prefabs")]
    public List<GameObject> Q1_Cube_Prefabs;
    public List<GameObject> Q2_Cube_Prefabs;
    public List<GameObject> Q3_Cube_Prefabs;
    public List<GameObject> Q4_Cube_Prefabs;
    [Header("Cubes")]
    public List<GameObject> Cubes;
    Vector3 position;
    //public int RandomQuestion = Random.Range(1, 4);
    public int RandomQuestion = 2;
    //Quaternion rotation ;
    //Vector3 Question_position = Vector3.zero;

    // Start is called before the first frame update

    public override void EntityDispose()
    {

    }
    void Start()
    {
        //GetComponent<GameObject>().CompareTag("question")
        //玩家可選題目
        //int RandomQuestion = 1;
        //int RandomQuestion = Random.Range(1, 4);
        if (RandomQuestion == 1)
        {
            Question_1();
            print("Q1");
        }
        if (RandomQuestion == 2)
        {
            Question_2();
            print("Q2");
        }
        if (RandomQuestion == 3)
        {
            Question_3();
            print("Q3");
        }
        if (RandomQuestion == 4)
        {
            Question_4();
            print("Q4");
        }
        // position = new Vector3((float)0.98, (float)0.36, (float)-7.5);
        //Cubes.Add(Instantiate(Cube_Prefabs[10], position, Quaternion.identity));
        //foreach(GameObject cube in Cubes){
        //    print(this.Cubes+"okok");
        //    if(cube == null)
        //    Cubes.RemoveAll(item => item == null);
        //}
    }
    
    //生成(Cube, 物件的位置:生成點的位置, 物件的旋轉值:生成點的旋轉值);
        //Instantiate實例化(要生成的物件, 物件位置, 物件旋轉值)
    public void Question_1()
    {
        //生成題目
        Vector3 Question1_position = new Vector3((float)1.345, (float)0.2889, (float)3.9);
        Instantiate(Question_Prefabs[0], Question1_position, Quaternion.Euler(0, 180, 0));

        //要生成的物件。

        //BlueCuboid3
        position = new Vector3((float)0.98, (float)0.36, (float)3.544);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[0], position, Quaternion.identity));
       
        //RedCuboid3
        position = new Vector3((float)0.98, (float)0.36, (float)3.623);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[1], position, Quaternion.identity));

        //GreenCuboid3
        position = new Vector3((float)0.98, (float)0.36, (float)3.702);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[2], position, Quaternion.identity));

        //YellowCuboid3
        position = new Vector3((float)0.98, (float)0.36, (float)3.782);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[3], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)3.856);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[4], position, Quaternion.identity));

        //RedCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3((float)0.98, (float)0.36, (float)3.936);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[5], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)4.034);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[6], position, Quaternion.identity));

        //YellowCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)4.147);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[7], position, Quaternion.identity));

        //BlueCube
        position = new Vector3((float)0.98, (float)0.36, (float)4.225);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCube
        position = new Vector3((float)0.98, (float)0.36, (float)4.312);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_2()
    {
        //生成題目
        Vector3 Question2_position = new Vector3((float)1.362, (float)0.31, (float)3.811);
        Instantiate(Question_Prefabs[1], Question2_position, Quaternion.Euler(0, -90, 0));

        //要生成的物件。

        //BlueCuboid3
        position = new Vector3((float)0.98, (float)0.36, 6);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[0], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)4.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[1], position, Quaternion.identity));

        //BlueCuboid3
        position = new Vector3((float)0.98, (float)0.36, 3);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[2], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, (float) 0.36);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[3], position, Quaternion.identity));

        //YellowCube
        position = new Vector3((float)0.98, (float)0.36, (float)0.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[4], position, Quaternion.identity));

        //GreenCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3((float)0.98, (float)0.36, (float)-0.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[5], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)-0.36);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[6], position, Quaternion.identity));

        //RedCube2
        position = new Vector3((float)0.98, (float)0.36, -3);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[7], position, Quaternion.identity));

        //YellowCube
        position = new Vector3((float)0.98, (float)0.36, (float)-4.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, -6);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_3()
    {
        //生成題目
        Vector3 Question3_position = new Vector3((float)0.36, (float)0.2889, (float)4.1);
        Instantiate(Question_Prefabs[2], Question3_position, Quaternion.Euler(0, 180, 0));

        //要生成的物件。

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, 6);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[0], position, Quaternion.identity));

        //GreenCube
        position = new Vector3((float)0.98, (float)0.36, (float)4.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[1], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, 3);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[2], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, (float) 0.36);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[3], position, Quaternion.identity));

        //GreenCube
        position = new Vector3((float)0.98, (float)0.36, (float)0.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[4], position, Quaternion.identity));

        //BlueCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3((float)0.98, (float)0.36, (float)-0.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[5], position, Quaternion.identity));

        //YellowCuboid3
        position = new Vector3((float)0.98, (float)0.36, (float)-0.36);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[6], position, Quaternion.identity));

        //GreenCube
        position = new Vector3((float)0.98, (float)0.36, -3);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[7], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)-4.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, -6);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_4()
    {
        //生成題目
        Vector3 Question3_position = new Vector3((float)1.38, (float)0.2889, (float)3.75);
        Instantiate(Question_Prefabs[3], Question3_position, Quaternion.Euler(0, 180, 0));

        //要生成的物件。

        //GreenCuboid
        position = new Vector3((float)0.98, (float)0.36, 6);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[0], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)4.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[1], position, Quaternion.identity));

        //YellowCube
        position = new Vector3((float)0.98, (float)0.36, 3);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[2], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, (float) 0.36);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[3], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)0.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[4], position, Quaternion.identity));

        //YellowCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3((float)0.98, (float)0.36, (float)-0.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[5], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)-0.36);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[6], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3((float)0.98, (float)0.36, -3);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[7], position, Quaternion.identity));

        //YellowCuboid
        position = new Vector3((float)0.98, (float)0.36, (float)-4.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[8], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3((float)0.98, (float)0.36, -6);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void RockPaperScissors()
    {

    }
     
}



