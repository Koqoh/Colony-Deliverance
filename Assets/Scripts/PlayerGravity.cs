using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    List<Transform> Planets = new List<Transform>();
    
    [HideInInspector] 
    public Transform lowestDistance;
    Rigidbody rb;
    [SerializeField] float gravityStrength;
    bool thrustSwitch;
    void Start()
    {
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Planet")){
            Planets.Add(i.transform);
        }
        rb = GetComponent<Rigidbody>();
        lowestDistance = FindLowestDistance();
    }

    void Update(){
        lowestDistance = FindLowestDistance();
    }
    void FixedUpdate()
    {
        /*
        normalized gives direction of the closest planet

        */
            rb.AddForce(
                lowestDistance.position.normalized * -gravityStrength /
                (Mathf.Pow(Vector3.Distance(lowestDistance.position, Vector3.zero), 1.5f))
            );
    }

    private Transform FindLowestDistance()
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

