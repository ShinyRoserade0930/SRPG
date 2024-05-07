using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EasingEquations
{
    public static float Linear(float start, float end, float value)
    {
        return (end - start) * value + start;
    }

    public static float EaseOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }

    public static float EaseInOutQuad(float start, float end, float value)
    {
        value /= .5f;
        end -= start;
        if (value < 1)
            return end / 2 * value * value + start;
        --value;
        return -end / 2 * (value * (value - 2) - 1) + start;
    }

    public static float EaseInBack(float start, float end, float value)
    {
        end -= start;
        value /= 1;
        float s = 1.70158f;
        return end * value * value * ((s + 1) * value - s) + start;
    }

    public static float EaseOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value = (value / 1) - 1;
        return end * (value * value * ((s + 1) * value + s) + 1) + start;
    }
}
