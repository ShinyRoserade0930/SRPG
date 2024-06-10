using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The gameObject is only destroyed at the next frame.
// Unparent component first to prevent GetComponent getting unwanted component that are supposed to be destroyed.
// Might rewrite to use pool controller to reuse gameObjects rather than keep creating and destroying.
public static class GameObjectExtensions
{
    public static T AddChildComponent<T>(this GameObject obj) where T : MonoBehaviour
    {
        GameObject child = new GameObject(typeof(T).Name);
        child.transform.SetParent(obj.transform);
        return child.AddComponent<T>();
    }
}
