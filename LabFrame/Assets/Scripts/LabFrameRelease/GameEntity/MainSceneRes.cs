using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneRes : GameSceneEntityRes
{
    public PlayerEntity player;
    public GameObject NPCHand;
    public List<BlockEntity> puzzle;
    public NPCEntity nurse;
    public Animator NPCanimator;
    public GameObject vrCamera;
    public Canvas MainSceneUI;
    public CameraEntity eyeCamera;
    //public RecognizerEntity recognizerEntity;
    public List<AudioClip> speechClip;
    public List<GameObject> ObjectList;
    public Transform PutPosition;
    //public List<TimerEntity> TimerList;
}
