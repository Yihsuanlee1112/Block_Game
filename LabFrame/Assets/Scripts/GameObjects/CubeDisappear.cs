using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDisappear : MonoBehaviour
{
    public GameObject cube;
    private void Start()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("aaa");
        if (collision.gameObject.CompareTag("Boundary"))
        {
            print("hi");
            StartCoroutine(RespwanCube());
        }
    }//積木碰到界線後消失
    IEnumerator RespwanCube()
    {
        Vector3 position = Vector3.zero;//new Vector3(Random.Range((float)11.5, (float)13.5), (float)0.2, Random.Range((float)-8.9, (float)8.9));
        //Quaternion rotation;
        
        
        Instantiate(cube, position, Quaternion.identity);
        Destroy(cube);
        yield return null;
    }//積木重新生成

}
