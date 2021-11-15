using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDisappear : MonoBehaviour
{
    public GameObject cube;
    //public GameObject Initialize;
    private void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            RespawnCube();
        }
    }//積木碰到界線後消失
    public void RespawnCube()
    {
         this.transform.position =  new Vector3(12, 2, Random.Range((float)-7.0, (float)7.0));
    }
    //IEnumerator RespwanCube()
    //{
    //   
        //Vector3 position = new Vector3((float)8.8, 2, Random.Range((float)-7.0, (float)7.0));
        //Quaternion rotation;
        //Instantiate(cube, position, Quaternion.identity);
        //cube.GetComponent<Instantiate_Cube>().Cubes.Remove(this.gameObject);
        //Destroy(this.gameObject);
    //    yield return null;
    //}//積木重新生成

}
