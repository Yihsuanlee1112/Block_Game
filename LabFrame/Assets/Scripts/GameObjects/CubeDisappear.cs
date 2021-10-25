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
        Vector3 position = new Vector3((float)8.8, 2, Random.Range((float)-7.0, (float)7.0));
        //Quaternion rotation;
        Instantiate(cube, position, Quaternion.identity);
        Destroy(cube);
        yield return null;
    }//積木重新生成

}
