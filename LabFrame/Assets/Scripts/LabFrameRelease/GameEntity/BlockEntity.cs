using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEntity : GameEntityBase
{
    public bool _isChose = false;
    public Transform ansTransform;
    public override void EntityDispose()
    {

    }

    public void ToAns()
    {
        _isChose = true;
        gameObject.transform.position = ansTransform.position;
        gameObject.transform.rotation = ansTransform.rotation;
        Debug.Log(ansTransform.position);
    }
}
