using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables
{

    public static float thrustAcceleration;
 
    [SerializeField]
    private float floatSerializationHelper;                  //don't use for anything else
 
    public void OnAfterDeserialize()
    {
         thrustAcceleration = floatSerializationHelper;
    }
 
    public void OnBeforeSerialize()
    {
        floatSerializationHelper = thrustAcceleration;  // uncomment this if you want the field to reflect the value of the static field on playmode
    }
}
