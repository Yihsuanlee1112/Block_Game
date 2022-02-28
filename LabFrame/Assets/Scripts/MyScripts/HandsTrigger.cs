using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsTrigger : MonoBehaviour
{
    private NPCEntity NPCEntity;
    private BlockEntity MyPreCube;
    private int MyPreCubeIndex;
    private List<BlockEntity> Blocks;
    private RockPaperScissors RockPaperScissors;
    //private bool _NPCRemind;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)//other=>cube
    {
        var MyCube = other.GetComponent<BlockEntity>();//BLockEntity
        var index = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cubes.IndexOf(MyCube);//int
        if (other.gameObject.tag == "cube" && !PlayerEntity._take &&
            !other.GetComponent<BlockEntity>()._isChose && GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cubes.Contains(MyCube))
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
            Debug.Log("Old" + MyPreCube + MyPreCubeIndex);
            Debug.Log("New" + MyCube + index);
            Debug.Log(index);//int
            Debug.Log(index - MyPreCubeIndex);
            if (!BLockGameTask._playerRound)
            {
                //BLockGameTask._NPCRemind = true;
                Debug.Log("Wrong Action");
                //StartCoroutine(NPCEntity.NPCRemind());
                GameEventCenter.DispatchEvent("NPCRemind");//輪流拼
            }
            else if (other.gameObject.GetComponent<BlockEntity>() == GameObject.Find("Q1BlueCuboid3(Clone)").GetComponent<BlockEntity>())
            {
                Debug.Log(other.gameObject.GetComponent<BlockEntity>());
                //GameEventCenter.DispatchEvent("NPCRemind_Order"); 
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.SetParent(gameObject.transform);
            }
            else if (index > 0 && index < 10 && index - MyPreCubeIndex != 2
                || !GameObject.Find("Q1BlueCuboid3(Clone)").GetComponent<Rigidbody>().isKinematic)
            {
                Debug.Log("Wrong Cube, put 1 first");
                GameEventCenter.DispatchEvent("NPCRemind_Order");
                //StartCoroutine(NPCEntity.NPCRemind());
                other.gameObject.transform.parent = null;
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
            else if (GameObject.Find("Q1BlueCuboid3(Clone)").GetComponent<Rigidbody>().isKinematic)
            {
                Debug.Log("Catch " + other.name);
                Debug.Log("follow hand");
                Debug.Log(gameObject.name);
                Debug.Log(other.gameObject.name);
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.SetParent(gameObject.transform);
                MyPreCube = other.GetComponent<BlockEntity>();//BlockEntity
                MyPreCubeIndex = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cubes.IndexOf(MyPreCube);//int
                Debug.Log(MyPreCube + " " + MyPreCubeIndex);
            }
            if (!other.gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                PlayerEntity._take = false;
            }
            else
            {
                PlayerEntity._take = true;
            }
            MyCube = MyPreCube;
            index = MyPreCubeIndex;
            Debug.Log(MyCube + " " + MyPreCube);
            Debug.Log(index + " " + MyPreCubeIndex);
        }

        else if (other.gameObject.tag == "q" && PlayerEntity._take)
        {
            Debug.Log("Put toAns");
            var parent = GameObject.Find("Answer");
            //var parent = GameObject.FindGameObjectWithTag("QuestionArea");
            Debug.Log(parent);
            var cube = gameObject.transform.GetChild(5).gameObject.GetComponent<BlockEntity>();//hand底下的第6個
            //var cube = gameObject.transform.GetChild(0).gameObject.GetComponent<BlockEntity>();//FakeHand
            Debug.Log(cube);
            cube.GetComponent<Rigidbody>().useGravity = true;
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            cube.transform.SetParent(parent.transform);
            GameEventCenter.DispatchEvent("CubeAns", cube);
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(parent.transform.position);
            Debug.Log(cube.transform.position);

            //GetComponent<BoxCollider>().enabled = false;
            BLockGameTask._playerRound = false;
            PlayerEntity._take = false;
        }
        else if(other.gameObject.tag == "Rock4P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator4P");
            GameEventCenter.DispatchEvent("FourPlayerShowPaperResult");
            GameObject.FindGameObjectWithTag("Paper4P").SetActive(false);
            GameObject.FindGameObjectWithTag("Scissors4P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose rock");
        }
        else if(other.gameObject.tag == "Scissors4P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator4P");
            GameEventCenter.DispatchEvent("FourPlayerShowRockResult");
            GameObject.FindGameObjectWithTag("Paper4P").SetActive(false);
            GameObject.FindGameObjectWithTag("Rock4P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose Scissors");
        }
        else if(other.gameObject.tag == "Paper4P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator4P");
            GameEventCenter.DispatchEvent("FourPlayerShowScissorsResult");
            GameObject.FindGameObjectWithTag("Rock4P").SetActive(false);
            GameObject.FindGameObjectWithTag("Scissors4P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose paper");
        }
        else if(other.gameObject.tag == "Rock2P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator2P");
            GameEventCenter.DispatchEvent("TwoPlayerShowScissorsResult");
            GameObject.FindGameObjectWithTag("Paper2P").SetActive(false);
            GameObject.FindGameObjectWithTag("Scissors2P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose rock");
        }
        else if(other.gameObject.tag == "Scissors2P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator2P");
            GameEventCenter.DispatchEvent("TwoPlayerShowPaperResult");
            GameObject.FindGameObjectWithTag("Paper2P").SetActive(false);
            GameObject.FindGameObjectWithTag("Rock2P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose scissors");
        }
        else if(other.gameObject.tag == "Paper2P")
        {
            GameEventCenter.DispatchEvent("CloseAnimator2P");
            GameEventCenter.DispatchEvent("TwoPlayerShowRockResult");
            GameObject.FindGameObjectWithTag("Rock2P").SetActive(false);
            GameObject.FindGameObjectWithTag("Scissors2P").SetActive(false);
            BLockGameTask._userChooseRPS = true;
            Debug.Log("User choose paper");
        }
    }
}

 
    
