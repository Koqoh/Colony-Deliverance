using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    GameObject Player;
    Rigidbody rb;
    [SerializeField] float thrustAcceleration;
    public static float power; //this is for animating fire and sound, goes from 0,0 to 1.0


    public bool thrusting;

    void Start()
    {
        Player = GameObject.Find("ship");

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;


    }

    void Update()
    {
        thrusting = Input.GetKey(KeyCode.W);


    }

    void FixedUpdate()
    {
        ProcessThrust();
        UpdatePower();
    }

    void ProcessThrust(){
        if(thrusting){
            rb.AddForce((Player.transform.up * -thrustAcceleration * power)/* / (transform.position.z/10f+1f)*/, ForceMode.VelocityChange);
        }
    }

    private void UpdatePower()
    {
        if (thrusting)
        {
            power += 0.05f;
        }
        else
        {
            power = 0;
        }
        power = Mathf.Clamp(power, 0, 1);
    }
}
