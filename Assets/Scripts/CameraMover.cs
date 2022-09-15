using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public GameObject Planet;
    GameObject player;
    Rigidbody rb;
    public static Transform rotationTarget;
    public float targetAngle = 0; 
    float currentAngle;
    float angularAcceleration;
    float angularVelocity = 0;
    public float maxAngularAcceleration = 720; // degrees/second^2
    public float maxAngularVelocity = 360; // degrees/second
    public float proportionalGain = 30; 
    public float differentialGain = 5; 
    private float lastError; 


    void Start()
    {
        rb = Planet.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        targetAngle = transform.eulerAngles.z; // get the current angle just for start
        currentAngle = targetAngle;
    }

    void Update()
    {
        RotateCamera();
    }
    private void FixedUpdate() {
        
        //TODO////////////////
        //implement camera noise sway with speed
    }

    private void RotateCamera()
    {
        //finds the planet closest to the player, possibly needs phasing out in favor or multiple planets affecting the player?

        targetAngle = -Mathf.Atan2(rotationTarget.position.x, rotationTarget.position.y) * 180 / Mathf.PI + 180;

        var error = translateAngle(targetAngle - currentAngle);
        var diff = (error - lastError) / Time.deltaTime; // calculate differential error
        lastError = error;
        
        angularAcceleration = error * proportionalGain + diff * differentialGain;
        angularAcceleration = Mathf.Clamp(angularAcceleration, -maxAngularAcceleration, maxAngularAcceleration);
        
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity = Mathf.Clamp(angularVelocity, -maxAngularVelocity, maxAngularVelocity);
        
        currentAngle += angularVelocity * Time.deltaTime; // apply the rotation to the angle
        transform.rotation = Quaternion.Euler(0, 0, translateAngle(currentAngle));

        //var radConvert = Mathf.PI/180;
        transform.position = new Vector3(Mathf.Sin(-currentAngle * Mathf.PI/180f), Mathf.Cos(-currentAngle * Mathf.PI/180f), -5) * (rb.velocity.magnitude / 4 + 1);

    }

    // Takes any angle and translates it to be between -180 and 180 degrees
    float translateAngle(float theta)
    {
        float r = (theta - 180f) % 360f;
        return (r < 0 ? r + 360f : r) - 180f;
    }
}
