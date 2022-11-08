using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Vr_Rotate : Gun_Rotate
{
    [SerializeField] private GameObject handle;
    
    protected override void Update()
    {
        AimAtDirection();
    }

    private void AimAtDirection()
    {
        Vector3 aimDir = handle.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-aimDir);
        // Debug.DrawRay(transform.position, -(handlePos - transform.position), Color.magenta);
        // Debug.DrawLine(transform.position, handlePos, Color.cyan);
    }
}
