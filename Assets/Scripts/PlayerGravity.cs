using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    List<Transform> Planets = new List<Transform>();
    
    [HideInInspector] 
    Transform lowestDistance;
    Rigidbody rb;
    [SerializeField] float gravityStrength;
    bool thrustSwitch;
    void Start()
    {
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Planet")){
            Planets.Add(i.transform);
        }
        rb = GetComponent<Rigidbody>();
        CameraMover.rotationTarget = lowestDistance = FindLowestDistance();
    }

    void Update(){
        CameraMover.rotationTarget = lowestDistance = FindLowestDistance();
    }
    void FixedUpdate()
    {
        /*
        normalized gives direction of the closest planet

        */
            //we need the camera to be affected by the larger planet if the larger planet's gravity is affecting the player more, we do this using vector3.magnitude.
            rb.AddForce(
                transform.position.normalized * -gravityStrength /
                (Mathf.Pow(Vector3.Distance(lowestDistance.position, Vector3.zero), 1.5f))
            );
    }

    private Transform FindLowestDistance() //quite proud of this one, honestly
    {
        Transform closest = Planets[0];
        float distance = float.MaxValue;

        foreach(Transform i in Planets)
        {
            var newDistance = Vector3.Distance(i.transform.position, Vector3.zero);
            if(newDistance < distance){
                distance = (float) newDistance;
                closest = i;
            }    
        }
        return closest;
    }
}

