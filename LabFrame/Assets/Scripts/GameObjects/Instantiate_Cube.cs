using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Cube : MonoBehaviour
{
    public GameObject InstantiateCube; //物件的生成點。

    [Header("Cubes")]
    public List<GameObject> Cubes;
    

    // Start is called before the first frame update
    void Start()
    {
        //要生成的物件。

        Vector3 position;
        //Quaternion rotation ;
        Vector3 position1 = Vector3.zero;
        //BlueCube
        position = new Vector3(Random.Range((float)11.5, (float)13.5), 2, Random.Range((float)-8.9, (float)-6));
        Instantiate(Cubes[0], position1, Quaternion.identity);
        
        //BlueCuboid
        position = new Vector3((float)12.5, 2, Random.Range((float)-5.5, (float)-1.0));
        Instantiate(Cubes[1], position, Quaternion.identity);

        //GreenCube
        position = new Vector3(Random.Range((float)11.5, (float)13.5), 2, Random.Range((float)-0.5, (float)2.5));
        Instantiate(Cubes[2], position, Quaternion.identity);

        //GreenCuboid
        position = new Vector3((float)12.5, 2, Random.Range((float)3.0, (float)5.5));
        Instantiate(Cubes[3], position, Quaternion.identity);

        //RedCube
        position = new Vector3(Random.Range((float)11.5, (float)13.5), 2, Random.Range((float)6.0, (float)7.5));
        Instantiate(Cubes[4], position, Quaternion.identity);
                
        //RedCuboid
        position = new Vector3((float)12.5, 2, Random.Range((float)8.0, (float)8.9));
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        Instantiate(Cubes[5], position, Quaternion.identity);
        

        //生成(Cube, 物件的位置:生成點的位置, 物件的旋轉值:生成點的旋轉值);
        //Instantiate實例化(要生成的物件, 物件位置, 物件旋轉值);

    }
}



