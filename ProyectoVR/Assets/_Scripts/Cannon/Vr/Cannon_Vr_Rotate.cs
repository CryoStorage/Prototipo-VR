using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Vr_Rotate : Gun_Rotate
{
    [SerializeField] private GameObject handle;
    
    protected override void Update()
    {
        LookAtRotate();
    }

    private void LookAtRotate()
    {
        Vector3 handlePos = transform.TransformPoint(handle.transform.position);
        transform.LookAt(handlePos);
        Debug.DrawRay(transform.position, -(handlePos - transform.position), Color.magenta);
        Debug.DrawLine(transform.position, handlePos, Color.cyan);
    }
}
