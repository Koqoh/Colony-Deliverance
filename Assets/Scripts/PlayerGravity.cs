using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    //List<Transform> Planets = new List<Transform>();
    
    [HideInInspector] 
    static Transform lowestDistance;
    Rigidbody rb;
    [SerializeField] float gravityStrength;
    bool thrustSwitch;
    void Start()
    {
  
        rb = GetComponent<Rigidbody>();

        lowestDistance = transform;
        CameraMover.rotationTarget = lowestDistance;
    }

    void Update(){
        FindLowestDistance();
        CameraMover.rotationTarget = lowestDistance;
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

    private void FindLowestDistance() //quite proud of this one, honestly
    {
        //float distance = float.MaxValue;

        //foreach(Transform i in Planets)
        //{
            var thisDistance = Vector3.Distance(transform.position, Vector3.zero);
            var oldDistance = Vector3.Distance(lowestDistance.position, Vector3.zero);
            Debug.Log("o" + oldDistance);
            Debug.Log("t" + thisDistance);
            if(thisDistance < oldDistance){
                lowestDistance = transform;
            }    
        //}
    }
/*    private void FindLowestDistance() //quite proud of this one, honestly
    {
        Transform closest = Vector3.Max;
        float distance = float.MaxValue;

        foreach(Transform i in Planets)
        {
            var newDistance = Vector3.Distance(transform.position, Vector3.zero);
            if(newDistance < distance){
                distance = (float) newDistance;
                closest = i;
            }    
        }
        lowestDistance = closest;
    }
*/
}

