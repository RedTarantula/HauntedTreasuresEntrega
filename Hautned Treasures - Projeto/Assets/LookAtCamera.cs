using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera c;
    private float yStare;
    public bool keepRotation;
    
    private void Start()
    {
        c = Camera.main;
        yStare = transform.position.y;
    }

    private void Update()
    {
        Vector3 transformPosition = c.transform.position;
        if (keepRotation)
        {
            transformPosition = new Vector3(transformPosition.x, yStare, transformPosition.z);
        }
        transform.LookAt(transformPosition);
    }
}
