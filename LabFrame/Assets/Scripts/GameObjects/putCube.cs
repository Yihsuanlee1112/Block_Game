using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 每個積木自身確認擺放是否錯誤 播放 wrongSound (可播放)
public class putCube : MonoBehaviour
{
    public CheckFormerCube checkFormer;
    public Instantiate_Cube instantiate;
    private int i;
    AudioClip clip;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        checkFormer = FindObjectOfType<CheckFormerCube>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider answerCube)
    {
        //Get Cube name without "(Clone)"
        string cubeName = answerCube.name;
        int delStr = cubeName.IndexOf("(Clone)");
        print(cubeName + "I took");
        if (delStr >= 0)
        {
            cubeName = cubeName.Remove(delStr);
        }
        print("put on..." + gameObject.name);
        //CheckformerCube();

        if (gameObject.name == cubeName)
        {
            print("stick");


            Debug.Log(answerCube);
            answerCube.transform.parent = gameObject.transform;
            print(answerCube.transform.parent + " is my father");
            //answerCube.transform.localScale = gameObject.transform.localScale;
            //print(answerCube.transform.localScale);
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);//相對於父物件的位置
            answerCube.transform.parent = null;

            // 入口
            if (instantiate.RandomQuestion == 1) 
            { 
                checkFormer.CheckQ1Former(answerCube);
            }
            //if (instantiate.RandomQuestion == 1) { StartCoroutine(GetComponent<CheckFormerCube>().CheckQ1Former(answerCube)); }
        }
        else if (gameObject.name != cubeName)
        {
            answerCube.transform.parent = gameObject.transform;
            print(answerCube.transform.parent + " is my father");
            //answerCube.transform.localScale = gameObject.transform.localScale;
            //print(gameObject.transform.localScale);
            //print(answerCube.transform.localScale);
            answerCube.transform.rotation = gameObject.transform.rotation;
            answerCube.transform.localPosition = new Vector3(0.5f, 0.5f, -0.5f);
            answerCube.transform.parent = null;
            clip = Resources.Load<AudioClip>("AudioClip/wrongSound");
            myAudioSource.PlayOneShot(clip);
            Debug.Log(clip);
            //GameAudioController.Instance.PlayOneShot(clip);
            //answerCube.GetComponent<Animator>().SetBool("isRightcube", false);
            //answerCube.GetComponent<Animator>().SetBool("isWrongcube", true);
            Debug.Log("play animator");
            Debug.Log("transform");
            answerCube.transform.SetPositionAndRotation(new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0)), Quaternion.Euler(new Vector3(0, 0, 0)));
        }

    }
    /*public bool CheckQ1Former(Collider Cube)
    //public IEnumerator CheckQ1Former(Collider Cube)
    {
        Collider[] Q1Quad = {
            GameObject.Find("RedCube(Q1Quad0)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCube(Q1Quad1)").GetComponent<BoxCollider>(),
            GameObject.Find("YellowCuboid(Q1Quad2)").GetComponent<BoxCollider>(),
            GameObject.Find("GreenCuboid(Q1Quad3)").GetComponent<BoxCollider>(),
            GameObject.Find("RedCuboid(Q1Quad4)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCuboid(Q1Quad5)").GetComponent<BoxCollider>(),
            GameObject.Find("YellowCuboid3(Q1Quad6)").GetComponent<BoxCollider>(),
            GameObject.Find("GreenCuboid3(Q1Quad7)").GetComponent<BoxCollider>(),
            GameObject.Find("RedCuboid3(Q1Quad8)").GetComponent<BoxCollider>(),
            GameObject.Find("BlueCuboid3(Q1Quad9)").GetComponent<BoxCollider>(),
        };

        bool flag = true;
        Debug.Log("I'm checking");
        print("fucking bitch");
        if (Cube == GameObject.Find("RedCube(Clone)").GetComponent<BoxCollider>()) { i = 0; }
        if (Cube == GameObject.Find("BlueCube(Clone)").GetComponent<BoxCollider>()) { i = 1; }
        if (Cube == GameObject.Find("YellowCuboid(Clone)").GetComponent<BoxCollider>()) { i = 2; }
        if (Cube == GameObject.Find("GreenCuboid(Clone)").GetComponent<BoxCollider>()) { i = 3; }
        if (Cube == GameObject.Find("RedCuboid(Clone)").GetComponent<BoxCollider>()) { i = 4; }
        if (Cube == GameObject.Find("BlueCuboid(Clone)").GetComponent<BoxCollider>()) { i = 5; }
        if (Cube == GameObject.Find("YellowCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 6; }
        if (Cube == GameObject.Find("GreenCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 7; }
        if (Cube == GameObject.Find("RedCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 8; }
        if (Cube == GameObject.Find("BlueCuboid3(Clone)").GetComponent<BoxCollider>()) { i = 9; }


        while (true)
        {
            Debug.Log("in while " + Cube);
            Debug.Log(Q1Quad[i]);
            if (i == 9)
            {
                print("good job!!");

                clip = Resources.Load<AudioClip>("AudioClip/correctSound");
                myAudioSource.PlayOneShot(clip);

                // 共用 putcube 的 audioSource
                //putcube.GetComponent<AudioSource>().PlayOneShot(clip);

                // 睿哲
                //audioSource.clip = correctSound;
                //audioSource.Play();

                // 框架
                //GameAudioController.Instance.PlayOneShot(clip);

                // 讓putCube播
                //flag = true;

                //Cube.GetComponent<Animator>().SetBool("isWrongcube", false);
                //Cube.GetComponent<Animator>().SetBool("isRightcube", true);
                Debug.Log(clip);
                Cube.GetComponent<Rigidbody>().isKinematic = true;
                print("this " + Cube.name + "iskinematic");
                flag = true;
                break;
            }
            else if (Q1Quad[i].isTrigger == false && Q1Quad[i + 1].isTrigger == false)
            {
                print("great job!!");
                clip = Resources.Load<AudioClip>("AudioClip/wrongSound");
                myAudioSource.PlayOneShot(clip);
                
                clip = Resources.Load<AudioClip>("AudioClip/wrongSound");
                audioSource.PlayOneShot(clip);
                
                //audioSource.clip = correctSound;
                //audioSource.Play();
                //audioSource.PlayOneShot(correctSound);
                //Debug.Log(clip);
                //GameAudioController.Instance.PlayOneShot(clip);
                // Cube.GetComponent<Animator>().SetBool("isWrongcube", false);
                // Cube.GetComponent<Animator>().SetBool("isRightcube", true);
                Cube.GetComponent<Rigidbody>().isKinematic = true;
                print("this " + Cube.name + "iskinematic");
                flag = true;
                break;
            }
            else if (Q1Quad[i].isTrigger == false && Q1Quad[i + 1].isTrigger == true)
            {
                Debug.Log("wrong");
                print("put former first!!");
                clip = Resources.Load<AudioClip>("AudioClip/wrongSound");
                myAudioSource.PlayOneShot(clip);
                //audioSource.PlayOneShot(clip);
                //Debug.Log(clip);
                //GameAudioController.Instance.PlayOneShot(clip);
                //Cube.GetComponent<Animator>().SetBool("isRightcube", false);
                //Cube.GetComponent<Animator>().SetBool("isWrongcube", true);
                print("music");
                Cube.transform.SetPositionAndRotation(new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0)), Quaternion.Euler(new Vector3(0, 0, 0)));
                flag = false;
                break;
            }
            else if (Q1Quad[i].isTrigger == true && Q1Quad[i + 1].isTrigger == true)
            {
                print("try it again");
                clip = Resources.Load<AudioClip>("AudioClip/wrongSound");
                myAudioSource.PlayOneShot(clip);
                // Debug.Log(clip);
                //audioSource.PlayOneShot(clip);
                //Debug.Log(clip);
                //GameAudioController.Instance.PlayOneShot(clip);
                //Cube.GetComponent<Animator>().SetBool("isRightcube", false);
                //Cube.GetComponent<Animator>().SetBool("isWrongcube", true);
                Cube.transform.position = new Vector3(12, 2, UnityEngine.Random.Range((float)-7.0, (float)7.0));
                print("you can do it");
                flag = false;
                break;
            }
            print("out of while loop");
            //Cube.GetComponent<Animator>().SetBool("isWrongcube", false);
            //Cube.GetComponent<Animator>().SetBool("isRightcube", false);
            break;
        }
        return flag;
        //StartCoroutine(ActionOne());
        //StartCoroutine(ActionTwo());
        //yield return flag;
    }*/
}

