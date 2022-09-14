using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimator : MonoBehaviour
{
    Transform red;
    Transform white;
    void Start()
    {
        red = transform.GetChild(0);
        white = transform.GetChild(1);
        
    }
    private void Update() {
        transform.localScale = new Vector3(1, ShipThrust.power, 1);
    }

    void FixedUpdate()
    {
        red.Rotate(Vector3.up, -1);
        white.Rotate(Vector3.up, 1);
    }

}
