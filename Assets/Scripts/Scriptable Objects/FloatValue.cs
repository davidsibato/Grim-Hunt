using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Float", menuName ="Grim Hunt / Float")]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    [NonSerialized] public float RuntimeValue;
    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
