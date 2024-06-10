using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Tweener : Tweener
{
    public Vector3 startTweenValue;
    public Vector3 endTweenValue;
    public Vector3 currentTweenValue { get; private set; }

    protected override void OnUpdate()
    {
        currentTweenValue = (endTweenValue - startTweenValue) * currentValue + startTweenValue;
        base.OnUpdate();
    }
}
