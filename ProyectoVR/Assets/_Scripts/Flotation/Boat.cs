using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Bouyancy
{
    [SerializeField]private GameObject[] floatPoints = new GameObject[4];
    private Vector3[] _floatPoints = new Vector3[4];
    [SerializeField]private GameObject[] movers;
    // Start is called before the first frame update
    protected override void Start()
    {
        Prepare();
    }

    protected override void Float()
    {
        float deltaHeight = transform.position.y - waterHeight;
        
        switch (deltaHeight)
        {
            case <0:
                foreach (var point in _floatPoints)
                {
                    Rb.AddForceAtPosition(FloatForce(deltaHeight),point, ForceMode.Force);
                }
                _underWater = true;
                ChangeState(_underWater);
                break;
            case >= 0:
                _underWater = false;
                ChangeState(_underWater);
                break;
        }
        

    }

    protected override void FixedUpdate()
    {
        GetFloatPoints();
        base.FixedUpdate();
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        foreach (var point in _floatPoints)
        {
            Gizmos.DrawSphere(point,.3f);
            Debug.DrawLine(point, transform.up);

        }
    }


    void Move(Vector3 force, Vector3 point)
    {
        if (movers.Length == 0) return;
        Rb.AddForceAtPosition(force,point,ForceMode.Impulse);

    }

    private Vector3 GetForce()
    {
        Vector3 result = new Vector3();
        return result;
    }

    void GetFloatPoints()
    {
        for (int i = 0; i < floatPoints.Length; i++)
        {
            _floatPoints[i] = floatPoints[i].transform.position;
        }
    }
    
    protected override void Prepare()
    {
        base.Prepare();
        // movers = new GameObject[movers.Length];
    }
    
}
