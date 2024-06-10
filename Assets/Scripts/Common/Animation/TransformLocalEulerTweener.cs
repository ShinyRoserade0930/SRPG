using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLocalEulerTweener : Vector3Tweener
{
    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.localEulerAngles = currentTweenValue;
    }
}
