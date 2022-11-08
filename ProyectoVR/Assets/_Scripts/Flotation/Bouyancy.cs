using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody))]
public class Bouyancy : MonoBehaviour
{
    [Header("Water Parameters")]
    [SerializeField] private float waterDrag = 4f;
    [SerializeField] private float waterAngularDrag = 2f;
    [SerializeField] private float floatForce = 12f;
    [SerializeField] protected float waterHeight = 0;
    [Header("Air Parameters")]
    [SerializeField] private float airDrag = 0f;
    [SerializeField] private float airAngularDrag = 0f;

    protected Rigidbody Rb;
    protected bool _underWater;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
      
    }

    protected virtual void FixedUpdate()
    {
        Float();
    }

    protected virtual void Float()
    {
        float deltaHeight = transform.position.y - waterHeight;

        switch (deltaHeight)
        {
            case <0:
               Rb.AddForceAtPosition(FloatForce(deltaHeight),transform.position,ForceMode.Force);
                _underWater = true;
                ChangeState(_underWater);
                break;
            case >= 0:
                _underWater = false;
                ChangeState(_underWater);
                break;
        }
    }

    protected Vector3 FloatForce(float deltaHeight)
    {
        Vector3 force = Vector3.up * (floatForce * Mathf.Abs(deltaHeight));
        return force;
    }

    protected void ChangeState(bool state)
    {
        switch (state)
        {
            case true:
               Rb.drag = waterDrag;
               Rb.angularDrag = waterAngularDrag;
                break;
            case false: 
               Rb.drag = airDrag;
               Rb.angularDrag = airAngularDrag;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter");
        if (!other.CompareTag("WaterLevel")) return;
        waterHeight = other.transform.position.y + (other.transform.lossyScale.y * .5f);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("triggerExit");
        if (!other.CompareTag("WaterLevel")) return;
        waterHeight = 0f;
    }

    protected virtual void Prepare()
    {
        try
        {
            Rb = GetComponent<Rigidbody>();
        }
        catch { Debug.Log("Could not find RigidBody"); }
        
    }
}
