using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLockGameTask : TaskBase
{
    /*
     * [Header("Question Prefabs")]
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
    public int RandomQuestion = 2;
    */
    private PlayerEntity player;
    private NPCEntity npc;
    private List<BlockEntity> Q1_cube;
    private List<BlockEntity> Q2_cube;
    private List<BlockEntity> Q3_cube;
    private List<BlockEntity> Q4_cube;
    private List<BlockEntity> Cubes;
    //private HandsTrigger MyPreCube;
    //private HandsTrigger MyPreCubeIndex;
    //private HandsTrigger Blocks;
    //private List<GameObject> objectlist;
    private CameraEntity eyecamera;
    private Canvas mainSceneUI;
    private Instantiate_Cube instantiate_Cube;
    private RockPaperScissors RockPaperScissors;
    private AudioClip clip;
    private Animator TeacherAnimator;
    //private Animator FourP1Ani, FourP2Ani, FourP3Ani, TwoPAni;
    //private Animator RPS_Animator;

    //private HandsTrigger PlayerHand;
    //private RecognizerEntity recognizerEntity;
    private string focusName;
    public static bool _userChooseRPS = false;
    public static bool _playerRound = true;//原本是false
    public bool _BlockFinished = false;
    public static bool _usersayhello = false;
    public static bool _talking = false;
    public static bool _npcremind = false;
    public static bool _eyetimerfinish = false;
    public static bool _waitforwatch = false;
    public static int answerindex = 0;
    //public static bool _NPCRemind = false;
    public int TalkScore = 0;//recognizerEntity

    public override IEnumerator TaskInit()
    {
        GameEventCenter.AddEvent("CheckCube", CheckCube);
        GameEventCenter.AddEvent<BlockEntity>("CubeAns", CubeAns);
        GameEventCenter.AddEvent<string>("GetFocusName", GetFocusName);
        GameEventCenter.AddEvent("AddCubesToList", AddCubesToList);
        //GameEventCenter.AddEvent("RPS2P", RPS2P);
        //GameEventCenter.AddEvent("RPS4P", RPS4P);
        //GameEventCenter.AddEvent("Close4PAni", Close4PAni);

        //GameEventCenter.AddEvent("NPC_Remind", NPC_Remind);
        //GameEventCenter.AddEvent("NPC_Remind2", NPC_Remind2);
        //載入MainSceneRes
        player = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().player;
        npc = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().npc;
        instantiate_Cube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Instantiate_Cube;
        RockPaperScissors = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().RockPaperScissors;
        Q1_cube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Q1_cube;
        Q2_cube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Q2_cube;
        Q3_cube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Q3_cube;
        Q4_cube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Q4_cube;
        Cubes = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cubes;
        //MyPreCube = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().MyPreCube;
        //MyPreCubeIndex = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().MyPreCubeIndex;
        //objectlist = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().ObjectList;
        npc.npchand = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().NPCHand;
        npc.speechList = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().speechClip;
        npc.animator = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().NPC_animator;
        //mainSceneUI = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().MainSceneUI;
        //recognizerEntity = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().recognizerEntity;


        //VRIK初始化
        player.Init(GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().vrCamera);

        //NPC初始化
        npc.EntityInit();

        //設定VR中可看到UI
        yield return new WaitForSeconds(0.5f);
        //mainSceneUI.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //mainSceneUI.planeDistance = 1;

        //啟動眼球追蹤
        yield return new WaitForSeconds(0.5f);
        //LabVisualization.VisualizationManager.Instance.VisulizationInit();
        //LabVisualization.VisualizationManager.Instance.StartDataVisualization();

        eyecamera = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().eyeCamera;
        eyecamera.Init();
        answerindex = 0;   //初始化

        //語音Recognizer 初始化
        //recognizerEntity.Init();
        yield return null;
    }

    public override IEnumerator TaskStart()
    {
        TeacherAnimator = GameObject.Find("teacher").GetComponent<Animator>();
        //FourP1Ani = GameObject.Find("RockPaperScissors4P_1").GetComponent<Animator>();
        //FourP2Ani = GameObject.Find("RockPaperScissors4P_2").GetComponent<Animator>();
        //FourP3Ani = GameObject.Find("RockPaperScissors4P_3").GetComponent<Animator>();
        //TwoPAni = GameObject.Find("RockPaperScissors2P").GetComponent<Animator>();
        //RPS_Animator = GameObject.Find("RockPaperScissors4P_1").GetComponent<Animator>();

        //邀請小朋友一起堆積木
        //npc.animator.Play("Talk");
        //GameAudioController.Instance.PlayOneShot(npc.speechList[0]);
        //yield return new WaitForSeconds(1.5f);

        //打招呼
        //yield return SayHello();
        TeacherAnimator.SetBool("isSayingHello", true);
        clip = Resources.Load<AudioClip>("AudioClip/Teacher_SayHi");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length );
        Debug.Log("AudioClip/Teacher_SayHi" + clip.length);
        Debug.Log("打完招呼");
        TeacherAnimator.SetBool("isSayingHello", false);

        //老師開場
        TeacherAnimator.SetBool("isStandingAndTalking", true);
        clip = Resources.Load<AudioClip>("AudioClip/Teacher_Opening");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 3);
        Debug.Log("AudioClip/Teacher_Opening" + clip.length);
        Debug.Log("老師開完場");
        TeacherAnimator.SetBool("isStandingAndTalking", false);

        //老師說明遊戲規則
        TeacherAnimator.SetBool("isStandingAndTalking", true);
        clip = Resources.Load<AudioClip>("AudioClip/Teacher_Introduction");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 1);
        Debug.Log("AudioClip/Teacher_Introduction" + clip.length);
        Debug.Log("老師說完遊戲規則");
        TeacherAnimator.SetBool("isStandingAndTalking", false);

        //老師問選圖
        TeacherAnimator.SetBool("isAsking", true);
        clip = Resources.Load<AudioClip>("AudioClip/Teacher_Ask");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 3);
        Debug.Log("AudioClip/Teacher_Ask" + clip.length);
        Debug.Log("老師問完選圖");
        TeacherAnimator.SetBool("isAsking", false);

        //User跟其他三組猜拳
        
        GameEventCenter.DispatchEvent("FourPlayerRPS");
        while (!_userChooseRPS)
        {
            Debug.Log("User choose RPS");
            yield return new WaitUntil(() => _userChooseRPS);
        }
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 5; i++)
        {
            GameObject.FindWithTag("RPS").SetActive(false);
        }
        for (int i=0; i<3; i++)
        {
            GameObject.FindWithTag("Result").SetActive(false);
        }
        
        yield return new WaitForSeconds(10);

        //User跟對面NPC猜拳
        npc.animator.SetBool("isTalk", true);
        clip = Resources.Load<AudioClip>("AudioClip/NPC_WinnerFirst");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 3);
        npc.animator.SetBool("isTalk", false);
        GameEventCenter.DispatchEvent("TwoPlayerRPS");
        while (!_userChooseRPS)
        {
            Debug.Log("User choose RPS");
            yield return new WaitUntil(() => _userChooseRPS);
        }
        //TwoPAni = GameObject.Find("RockPaperScissors2P(Clone)").GetComponent<Animator>();
        //TwoPAni.SetBool("isRPS", true);
        yield return new WaitForSeconds(5);
        
        GameObject.FindWithTag("Result").SetActive(false);
        for (int i = 0; i < 2; i++)
        {
            GameObject.FindWithTag("RPS").SetActive(false);
        }


        yield return new WaitForSeconds(10);

        // 框架

        //規則說明要輪流拼
        //npc.animator.Play("Talk");
        npc.animator.SetBool("isTalk2", true);
        clip = Resources.Load<AudioClip>("AudioClip/NPC_Rule");
        GameAudioController.Instance.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Debug.Log("AudioClip/NPC_Rule" + clip.length);
        //GameAudioController.Instance.PlayOneShot(npc.speechList[5]);//NPC_Rule
        //yield return new WaitForSeconds(8.5f);
        npc.animator.SetBool("isTalk2", false);
        GameEventCenter.DispatchEvent("AddCubesToList");

        while (!_BlockFinished)
        {
            if (_playerRound)  //玩家回合
            {
                Debug.Log("User touch block"); 
                yield return new WaitUntil(() => !_playerRound);
            }
            else  //NPC回合
            {
                _npcremind = false;
                foreach (BlockEntity cube in Cubes)
                {
                    if (!cube._isChose)
                    {
                        npc.animator.Play("Puzzle"); //npc拿積木
                        yield return new WaitForSeconds(7);
                        if (!_npcremind)
                        {   
                            Debug.Log("NPC putting block");
                            GameEventCenter.DispatchEvent("CubeAns", cube);
                            _playerRound = true;
                        }
                        else
                        {
                            Debug.Log("wait for remind");
                            clip = Resources.Load<AudioClip>("AudioClip/NPC_Remind");
                            yield return new WaitForSeconds(clip.length);
                        }
                        break;
                        
                    }
                }
                
            }

            GameEventCenter.DispatchEvent("CheckCube");
            yield return new WaitForSeconds(2);
        }
        yield return null;
    }

    public override IEnumerator TaskStop()
    {
        yield return null;
    }

    public void AddCubesToList()
    {
        Debug.Log("find!!!");
        Q1_cube.Add(GameObject.Find("Q1BlueCuboid3(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1RedCuboid3(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1GreenCuboid3(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1YellowCuboid3(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1BlueCuboid(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1RedCuboid(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1GreenCuboid(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1YellowCuboid(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1BlueCube(Clone)").GetComponent<BlockEntity>());
        Q1_cube.Add(GameObject.Find("Q1RedCube(Clone)").GetComponent<BlockEntity>());
        Cubes.AddRange(Q1_cube);
        //foreach (BlockEntity cube in Cubes)
        //{
        //    Debug.Log(cube);
        //}
    }
    /*public void Instantiate_Cube()
    {
        if (RandomQuestion == 1)
        {
            Question_1();
            Debug.Log("Q1");
        }
        if (RandomQuestion == 2)
        {
            Question_2();
            Debug.Log("Q2");
        }
        if (RandomQuestion == 3)
        {
            Question_3();
            Debug.Log("Q3");
        }
        if (RandomQuestion == 4)
        {
            Question_4();
            Debug.Log("Q4");
        }

    }

    public void Question_1()
    {
        //生成題目
        Vector3 Question1_position = new Vector3((float)1.345, (float)0.2889, (float)3.9);
        Instantiate(Question_Prefabs[0], Question1_position, Quaternion.Euler(0, 0, 0));

        //要生成的物件。

        //BlueCuboid3
        position = new Vector3(12, (float)1.5, -4);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[0], position, Quaternion.identity));

        //RedCuboid3
        position = new Vector3(12, (float)1.5, (float)-5.5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[1], position, Quaternion.identity));

        //GreenCuboid3
        position = new Vector3(12, (float)1.5, -1);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[2], position, Quaternion.identity));

        //YellowCuboid3
        position = new Vector3(12, (float)1.5, (float)0.5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[3], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, 2);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[4], position, Quaternion.identity));

        //RedCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3(12, (float)1.5, (float)3.5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[5], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3(12, (float)1.5, -7);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[6], position, Quaternion.identity));

        //YellowCuboid
        position = new Vector3(12, (float)1.5, (float)6.5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[7], position, Quaternion.identity));

        //BlueCube
        position = new Vector3(12, (float)1.5, 5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCube
        position = new Vector3(12, (float)1.5, (float)-2.5);
        Cubes.Add(Instantiate(Q1_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_2()
    {
        //生成題目
        Vector3 Question2_position = new Vector3((float)1.345, (float)0.31, (float)3.811);
        Instantiate(Question_Prefabs[1], Question2_position, Quaternion.Euler(0, -90, 0));

        //要生成的物件。

        //BlueCuboid3
        position = new Vector3(12, (float)1.5, 6);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[0], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3(12, (float)1.5, (float)4.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[1], position, Quaternion.identity));

        //BlueCuboid3
        position = new Vector3(12, (float)1.5, 3);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[2], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, (float)1.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[3], position, Quaternion.identity));

        //YellowCube
        position = new Vector3(12, (float)1.5, (float)0.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[4], position, Quaternion.identity));

        //GreenCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3(12, (float)1.5, (float)-0.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[5], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, (float)-1.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[6], position, Quaternion.identity));

        //RedCube2
        position = new Vector3(12, (float)1.5, -3);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[7], position, Quaternion.identity));

        //YellowCube
        position = new Vector3(12, (float)1.5, (float)-4.5);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, -6);
        Cubes.Add(Instantiate(Q2_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_3()
    {
        //生成題目
        Vector3 Question3_position = new Vector3((float)1.5, (float)0.2889, (float)4.1);
        Instantiate(Question_Prefabs[2], Question3_position, Quaternion.Euler(0, 180, 0));

        //要生成的物件。

        //BlueCuboid
        position = new Vector3(12, (float)1.5, 6);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[0], position, Quaternion.identity));

        //GreenCube
        position = new Vector3(12, (float)1.5, (float)4.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[1], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, 3);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[2], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, (float)1.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[3], position, Quaternion.identity));

        //GreenCube
        position = new Vector3(12, (float)1.5, (float)0.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[4], position, Quaternion.identity));

        //BlueCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3(12, (float)1.5, (float)-0.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[5], position, Quaternion.identity));

        //YellowCuboid3
        position = new Vector3(12, (float)1.5, (float)-1.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[6], position, Quaternion.identity));

        //GreenCube
        position = new Vector3(12, (float)1.5, -3);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[7], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, (float)-4.5);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[8], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, -6);
        Cubes.Add(Instantiate(Q3_Cube_Prefabs[9], position, Quaternion.identity));
    }
    public void Question_4()
    {
        //生成題目
        Vector3 Question3_position = new Vector3((float)1.373, (float)0.2889, (float)3.75);
        Instantiate(Question_Prefabs[3], Question3_position, Quaternion.Euler(0, 180, 0));

        //要生成的物件。

        //GreenCuboid
        position = new Vector3(12, (float)1.5, 6);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[0], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, (float)4.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[1], position, Quaternion.identity));

        //YellowCube
        position = new Vector3(12, (float)1.5, 3);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[2], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, (float)1.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[3], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, (float)0.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[4], position, Quaternion.identity));

        //YellowCuboid
        //rotation = Quaternion.Euler(new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), 0));
        position = new Vector3(12, (float)1.5, (float)-0.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[5], position, Quaternion.identity));

        //RedCuboid
        position = new Vector3(12, (float)1.5, (float)-1.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[6], position, Quaternion.identity));

        //BlueCuboid
        position = new Vector3(12, (float)1.5, -3);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[7], position, Quaternion.identity));

        //YellowCuboid
        position = new Vector3(12, (float)1.5, (float)-4.5);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[8], position, Quaternion.identity));

        //GreenCuboid
        position = new Vector3(12, (float)1.5, -6);
        Cubes.Add(Instantiate(Q4_Cube_Prefabs[9], position, Quaternion.identity));
    }
    */
    
    public void CheckCube()
    {
        foreach (BlockEntity item in Cubes)
        {
            if (!item._isChose)
            {
                _BlockFinished = false;
                break;
            }
            else
            {
                _BlockFinished = true;
            }
        }
    }

    //public void RPS2P()
    //{
    //    RockPaperScissors.TwoPlayerRPS();
    //    TwoPAni = GameObject.Find("RockPaperScissors2P(Clone)").GetComponent<Animator>();
    //    TwoPAni.SetBool("isRPS", true);
    //    //TwoPAni.GetComponent<Animator>().SetBool("isRPS", true);
    //    Debug.Log("StartAni");
    //}
    //public void RPS4P()
    //{
        //RockPaperScissors.FourPlayerRPS();
        //FourP1Ani = GameObject.Find("RockPaperScissors4P_1(Clone)").GetComponent<Animator>();
        //FourP2Ani = GameObject.Find("RockPaperScissors4P_2(Clone)").GetComponent<Animator>();
        //FourP3Ani = GameObject.Find("RockPaperScissors4P_3(Clone)").GetComponent<Animator>();
        //FourP1Ani.SetBool("isRPS", true);
        //FourP2Ani.SetBool("isRPS", true);
        //FourP3Ani.SetBool("isRPS", true);
        //Debug.Log("StartAni");
    //}
    //public void Close4PAni()
    //{
    //    RockPaperScissors.CloseAnimator4P();
    //    //TwoPAni.SetBool("isRPS", false);
    //}

    public void TakeObject()//拼圖的氣球
    {
        var index = 2;/*Random.Range(0, 3);*/
        //npc.NPCTakeObject(objectlist[index]);
    }
    public void PutObject()
    {
        npc.NPCPutObject(GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().PutPosition);
    }
    public void CubeAns(BlockEntity cube)
    {
        cube.ToAns();
    }

    public void GetFocusName(string name)
    {
        focusName = name;
    }
    //public void NPC_Remind()
    //{
    //    StartCoroutine(npc.NPCRemind());
    //}
    //public void NPC_Remind2()
    //{
    //    npc.NPCRemind2();
    //}
}
