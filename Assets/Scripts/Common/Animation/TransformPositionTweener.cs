using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPositionTweener : Vector3Tweener
{
    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.position = currentTweenValue;
    }
}
