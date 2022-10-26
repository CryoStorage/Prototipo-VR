using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Rotate : Gun_Rotate
{
    [SerializeField]private float maxAngleX, maxAngleY = 45f;
    private float _minAngleX, _minAngleY;
    [Tooltip("Sensitivity Multiplier")]
    [SerializeField]private float sens = 1;

    [SerializeField] private GameObject handle;
    private Vector3 _handlePos;

    protected override void Start()
    {
        base.Start();
        Prepare();
        _minAngleX = maxAngleX - 360;
        _minAngleY = maxAngleY - 360;

    }

    protected override void Update()
    {
        LookAtRotate();

    }

    private void MouseRotate()
    {
        mouseX += Input.GetAxis("Mouse X") * sens;
        mouseY += Input.GetAxis("Mouse Y") * sens;
        mouseX = Mathf.Clamp(mouseX, _minAngleX, maxAngleX);
        mouseY = Mathf.Clamp(mouseY, _minAngleY, maxAngleY);
        Vector3 eulers = transform.localEulerAngles;

        eulers = new Vector3(-mouseY, mouseX, 0f);
        // eulers = new Vector3(Mathf.Clamp(eulers.x, _minAngleX, maxAngleX),
        //     Mathf.Clamp(eulers.y, _minAngleY, maxAngleY),0f);
        transform.localEulerAngles = eulers;
    }

    private void LookAtRotate()
    { 
        transform.LookAt(-_handlePos);
        _handlePos = handle.transform.position;

    }

    private void Prepare()
    {

    }
    
    

}
