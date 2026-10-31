using System.Collections.Generic;
using UnityEngine;

public class ShapeFillFunctionality : MonoBehaviour
{
    // Mirror's parent
    List<BoxCollider> pMirror;

    // Public Ray starting point.
    public Vector3 rayStartingPosition;
    // Public Ray direction
    public Vector3 rayRotation;
    // Public Ray's length
    float rayLength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pMirror = new List<BoxCollider>(GetComponentsInChildren<BoxCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
