using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puzzle" && !PlayerEntity._take && !other.GetComponent<BlockEntity>()._isChose)
        {
            if (!BLockGameTask._playerRound)
            {
                Debug.Log("Wrong Action");
                GameEventCenter.DispatchEvent("NPCRemind");
            }
            Debug.Log("Catch");
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.SetParent(gameObject.transform);
            PlayerEntity._take = true;
        }
        else if (other.gameObject.tag == "Box" && PlayerEntity._take)
        {
            Debug.Log("Ans");
            var parent = GameObject.Find("Puzzle");
            var puzzle = gameObject.transform.GetChild(5).gameObject.GetComponent<BlockEntity>();
            puzzle.GetComponent<Rigidbody>().useGravity = true;
            puzzle.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            puzzle.transform.SetParent(parent.transform);
            GameEventCenter.DispatchEvent("PuzAns", puzzle);
            BLockGameTask._playerRound = false;
            PlayerEntity._take = false;
        }
    }
}
