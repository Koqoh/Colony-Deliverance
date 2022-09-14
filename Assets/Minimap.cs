using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] float factor = 1000;
    float zPos;
    void Start()
    {
        if (factor == 0) factor = 1;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetTransform = transform.InverseTransformPoint(targetObject.transform.position);

        var xPos = targetTransform.x/factor;
        var yPos = targetTransform.y/factor;
        var zPos = transform.localPosition.z;

        xPos = Mathf.Clamp(xPos, -1.5f, 1.5f);
        yPos = Mathf.Clamp(yPos, -1.3f, 1.3f);

        Vector3 targetPosition = new Vector3(xPos, yPos, zPos);
        transform.localPosition = targetPosition;


        Debug.Log(factor);
        Debug.Log(xPos);
        Debug.Log(yPos);
        Debug.Log(zPos);

    }
}
