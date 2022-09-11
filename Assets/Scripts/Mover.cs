using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    GameObject Player;
    float thrust;
    Rigidbody rb;
    [SerializeField] float thrustAcceleration;


    public bool thrusting;

    void Start()
    {
        Player = GameObject.Find("ship");
        Debug.Log(Player);

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        //thrust = Player.GetComponent<PlayerRotater>().thrustAcceleration;
        Debug.Log(thrust);

    }

    void Update(){
        thrusting = Input.GetKey(KeyCode.W);
        thrust = thrustAcceleration;
    }    

    void FixedUpdate()
    {
        ProcessThrust();
    }

    void ProcessThrust(){
        if(thrusting){
            Debug.Log("thrusting");
            rb.AddForce((Player.transform.up * -thrust)/* / (transform.position.z/10f+1f)*/, ForceMode.VelocityChange);
        }
    }

}
