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
    void Start()
    {
  
        rb = GetComponent<Rigidbody>();

        FindLowestDistance();
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
            rb.AddForce(
                transform.position.normalized * -gravityStrength /
                (Mathf.Pow(Vector3.Distance(lowestDistance.position, Vector3.zero), 1.5f))
            );
    }

    private void FindLowestDistance() 
    //needs to set lowestDistance to a transform that is a lowest distance
    //needs to be independant of previous lowestDistance
    {
        float thisDistance = transform.position.magnitude;
        float oldDistance = lowestDistance.position.magnitude;

        if(lowestDistance == null || thisDistance <= oldDistance){
            lowestDistance = this.transform;
        }

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

