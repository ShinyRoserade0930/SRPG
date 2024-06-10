using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLocalPositionTweener : Vector3Tweener
{
    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.localPosition = currentTweenValue;
    }
}
