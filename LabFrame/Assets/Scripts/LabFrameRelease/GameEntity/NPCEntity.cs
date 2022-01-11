﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using SpeechLib;

public class NPCEntity : GameEntityBase
{
    public Action<GameEntityBase> Action;
    public Animator animator;
    public List<AudioClip> speechList;
    public GameObject npchand;
    private GameObject ObjectTaked;
    public static int Remindcount = 0;

    public override void EntityDispose()
    {

    }

    public override void EntityInit()
    {
        GameEventCenter.AddEvent("NPCRemind", NPCRemind);
    }

    //時好時壞(?)
    /*
     * public void NPCTalk()
    {
        Debug.Log("講話!");
        SpVoice npcsay = new SpVoice();
        npcsay.Speak(GameDataManager.FlowData.UserName, SpeechVoiceSpeakFlags.SVSFlagsAsync);
    }
    */
    public void NPCTakeObject(GameObject gameObject)
    {
        gameObject.transform.position = npchand.transform.position;
        gameObject.transform.parent = null;
        gameObject.transform.SetParent(npchand.transform);
        ObjectTaked = gameObject;
    }

    public void NPCPutObject(Transform puttransform)
    {
        ObjectTaked.transform.parent = null;
        ObjectTaked.transform.position = puttransform.position;
        ObjectTaked = null;
    }

    public void NPCRemind()
    {
        Remindcount++;
        BLockGameTask._npcremind = true;
        animator.Play("Talk");
        GameAudioController.Instance.PlayOneShot(speechList[6]);
    }
}