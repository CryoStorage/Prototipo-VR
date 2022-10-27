using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Mouse_Rotate : Gun_Rotate
{
    [SerializeField]private float maxAngleX, maxAngleY = 405f;
    private float _minAngleX, _minAngleY;
    [Tooltip("Sensitivity Multiplier")]
    [SerializeField]private float sens = 1;
    
    
    protected override void Start()
    {
        base.Start();
        _minAngleX = maxAngleX-60;
        _minAngleY = maxAngleY-60;

    }

    // Update is called once per frame
    protected override void Update()
    {
        MouseRotate();
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

        float radX = eulers.x * Mathf.Deg2Rad;
        float radY = eulers.y * Mathf.Deg2Rad;
        // Debug.Log("Y Axis" +eulers.x + " degrees are equal to " + radX + " radians.");
        Debug.Log("X Axis" +eulers.x + " degrees are equal to " + radY + " radians.");
    }
}
