using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimator : MonoBehaviour
{
    Transform red;
    Transform white;
    public GameObject varSource;//this gets us variables like thrust and velocity
    void Start()
    {
        red = gameObject.transform.GetChild(0);
        white = gameObject.transform.GetChild(1);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        red.Rotate(Vector3.up, -1);
        white.Rotate(Vector3.up, 1);
    }
}
