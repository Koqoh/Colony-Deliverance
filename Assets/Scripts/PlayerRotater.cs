using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    bool rotateR, rotateL;

    [SerializeField] private float rotationSpeed;

    [Header("Rotation Axis")]
    [Tooltip("brendan if you manage to get the three bools on one line in the inspector I will kiss you")]
    [SerializeField] bool x; 
    [Tooltip("brendan if you manage to get the three bools on one line in the inspector I will kiss you")]
    [SerializeField] bool y,z;
    Vector3 rotationAxis;
    float power;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        power = Util.PwrPercent(rotateL || rotateR, power);
        Debug.Log(power);
        ProcessRotation();
    }

    void Update()
    {
        //rotationAxis = new Vector3(System.Convert.ToSingle(x), System.Convert.ToSingle(y), System.Convert.ToSingle(z));
        //Debug.Log(rotationAxis);
        rotateL = Input.GetKey(KeyCode.A);
        rotateR = Input.GetKey(KeyCode.D);

        
    }



    void ProcessRotation(){
        //NEED TO FIX INTENDED GAME MECHANIC WITH GETTING STUCK ON SIDE ON PLANETS
        if(rotateL){

            rb.AddRelativeTorque(Vector3.forward * power);
        }
        else if(rotateR){

            rb.AddRelativeTorque(Vector3.back * power);
        }
    }
    
    void LateUpdate(){
        transform.position = Vector3.zero;
        
        var rot = transform.rotation;
        rot = new Quaternion(0,0,rot.z,rot.w);
        transform.rotation = rot;
        
    }
}