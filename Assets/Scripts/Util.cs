using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static float PwrPercent(bool on, float var, float max)
    {
        if (on)
        {
            var += 0.05f;
        }
        else
        {
            var = 0;
        }
        var = Mathf.Clamp(var, 0, max);
        return var;
    }
    public static float PwrPercent(bool on, float var)
    {
        if (on)
        {
            var += 0.05f;
        }
        else
        {
            var = 0;
        }
        return var;
    }
}
