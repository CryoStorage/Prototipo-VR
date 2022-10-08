using System;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsHands : MonoBehaviour
{
    [SerializeField] private Rigidbody parentRigidBody;
    private Rigidbody _rigidbody;
    [SerializeField] GameObject target;
    [SerializeField]private float frequency = 50;
    [SerializeField]private float rotFrequency = 100;
    [SerializeField]private float damping = 1;
    [SerializeField]private float rotDamping = .9f;
    
    void Start()
    {
        Prepare();
    }

    void FixedUpdate()
    {
        PidMovement();
        PidRotation();
    }

    private void PidMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5f * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target.transform.position - transform.position) * ksg + (parentRigidBody.velocity - _rigidbody.velocity) * kdg;
        
        _rigidbody.AddForce(force, ForceMode.Acceleration);
    }

    private void PidRotation()
    {
        float kp = (6f * rotFrequency) * (6f * rotFrequency) * 0.25f;
        float kd = 4.5f * rotFrequency * rotDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Quaternion q = target.transform.rotation * Quaternion.Inverse(transform.rotation);
        if (q.w < 0)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        q.ToAngleAxis(out float angle, out Vector3 axis);
        axis.Normalize();
        axis *= Mathf.Deg2Rad;
        Vector3 torque = ksg * axis * angle + -_rigidbody.angularVelocity * kdg;
        _rigidbody.AddTorque(torque, ForceMode.Acceleration);
    }

    private void Prepare()
    {
        if (_rigidbody != null) return;
        try
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        catch{ Debug.LogWarning("Could not find RigidBody");}

        _rigidbody.maxAngularVelocity = float.PositiveInfinity;


    }
}
