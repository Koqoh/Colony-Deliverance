using UnityEngine;
using System.Collections;

public class Revolution : MonoBehaviour {
    // Drag & drop the player in the inspector
    public Transform Target;
    
    public float RotationSpeed = 1;
    
    private float CircleRadius;
    
    public float ElevationOffset = 0;
    
    private Vector3 positionOffset;
    private float angle;
    void Start(){
        CircleRadius = Vector3.Distance (transform.position, Target.transform.position);
    }
    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos( angle ) * CircleRadius,
            Mathf.Sin( angle ) * CircleRadius,
            ElevationOffset
        );
        transform.position = Target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }
}