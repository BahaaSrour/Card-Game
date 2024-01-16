using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptables/Events")]
public class ScriptableEvent : ScriptableObject
{
    public event UnityAction unityAction;

    public void addListener(UnityAction value)
    {
        unityAction += value;
    }
    public void removeListener(UnityAction value)
    {
        try
        {
            if (unityAction != null)
            {
                unityAction -= value;
            }
        }
        catch
        {
            Debug.Log("it hasn't action added ");
        }

    }
    public void ClearAction()
    {
        unityAction = null;
    }
    public void Fire()
    {
        unityAction.Invoke();
    }
}

public class ScriptableEvent<T> : ScriptableObject
{
    public event UnityAction<T> unityAction;

    public void addListener(UnityAction<T> value)
    {
        unityAction += value;
    }
    public void removeListener(UnityAction<T> value)
    {
        try
        {
            if (unityAction != null)
            {
                unityAction -= value;
            }
        }
        catch
        {
            Debug.Log("it hasn't action added ");
        }

    }
    public void ClearAction()
    {
        unityAction = null;
    }
    public void Fire(T value)
    {
        unityAction.Invoke(value);
    }
}