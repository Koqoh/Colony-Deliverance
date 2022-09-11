using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    bool rotateR, rotateL;

    [SerializeField] private float rotationSpeed;

    [Header("Rotation Axis")]
    [Tooltip("brendan if you manage to get the three bools on one line I will kiss you")]
    [SerializeField] bool x; 
    [Tooltip("brendan if you manage to get the three bools on one line I will kiss you")]
    [SerializeField] bool y,z;
    Vector3 rotationAxis;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
       ProcessRotation();
    }

    void Update()
    {
        //rotationAxis = new Vector3(System.Convert.ToSingle(x), System.Convert.ToSingle(y), System.Convert.ToSingle(z));
        //Debug.Log(rotationAxis);
        rotateL = Input.GetKey(KeyCode.A);
        rotateR = Input.GetKey(KeyCode.D);

        //if(rotateL && rotateR)
        //    rotateL = rotateR = false;        
    }

    void ProcessRotation(){
        //NEED TO FIX INTENDED GAME MECHANIC WITH GETTING STUCK ON SIDE ON PLANETS
        if(rotateL){
            //transform.Rotate(Vector3.forward*rotationSpeed);

            rb.AddRelativeTorque(Vector3.forward*rotationSpeed);
        }
        else if(rotateR){
            //transform.Rotate(Vector3.back*rotationSpeed);

            rb.AddRelativeTorque(Vector3.back*rotationSpeed);
        }
    }

    void LateUpdate(){
        transform.position = Vector3.zero;
        
        var rot = transform.rotation;
        rot = new Quaternion(0,0,rot.z,rot.w);
        transform.rotation = rot;
        
    }
}
/*
    void ProcessRotation(){
        if(rotateL){
            transform.rotation *= Quaternion.Euler(Vector3.forward*rotationSpeed);
        }
        else if(rotateR){
            transform.rotation *= Quaternion.Euler(Vector3.back*rotationSpeed);
        }
        
    }

    void LateUpdate(){
        transform.position = Vector3.zero;

    }
}
*/