using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinValueModifier : ValueModifier
{
    public float min;

    public MinValueModifier(int sortOrder, float min) : base(sortOrder)
    {
        this.min = min;
    }

    public override float Modify(float fromValue, float toValue)
    {
        return Mathf.Min(toValue, min);
    }
}
