using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Cube : MonoBehaviour
{
    public GameObject InstantiateCube; //物件的生成點。

    [Header("Cube Prefabs")]
    public List<GameObject> Cube_Prefabs;
    [Header("Cubes")]
    public List<GameObject> Cubes;

    // Start is called before the first frame update
    void Start()
    {
        //要生成的物件。

        Vector3 position;
        //Quaternion rotation ;
        //Vector3 position1 = Vector3.zero;

        //BlueCube
        //position = new Vector3(Random.Range((float)8.3, (float)9.3), 2, Random.Range((float)-7.0, (float)7.0));
        position = new Vector3(0, (float)2.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[0], position, Quaternion.identity));

        //BlueCuboid
        //position = new Vector3((float)8.8, 2, Random.Range((float)-7.0, (float)7.0));
        position = new Vector3(0, (float)0.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[1], position, Quaternion.identity));

        //GreenCube
        //position = new Vector3(Random.Range((float)8.3, (float)9.3), 2, Random.Range((float)-7.0, (float)7.0));
        position = new Vector3(0, (float)1.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[2], position, Quaternion.identity));

        //GreenCuboid
        //position = new Vector3((float)8.8, 2, Random.Range((float)-7.0, (float)7.0));
        position = new Vector3(2, (float)0.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[3], position, Quaternion.identity));

        //RedCube
        //position = new Vector3(Random.Range((float)8.3, (float)9.3), 2, Random.Range((float)-7.0, (float)7.0));
        position = new Vector3(1, (float)1.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[4], position, Quaternion.identity));

        //RedCuboid
        //position = new Vector3((float)8.8, 2, Random.Range((float)-7.0, (float)7.0));
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3(-2, (float)0.5, 0);
        Cubes.Add(Instantiate(Cube_Prefabs[5], position, Quaternion.identity));
        //foreach(GameObject cube in Cubes){
        //    print(this.Cubes+"okok");
        //    if(cube == null)
        //    Cubes.RemoveAll(item => item == null);
        //}
        
        //生成(Cube, 物件的位置:生成點的位置, 物件的旋轉值:生成點的旋轉值);
        //Instantiate實例化(要生成的物件, 物件位置, 物件旋轉值)


    }
     
}



