using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Bouyancy
{
    [SerializeField]private GameObject[] floatPoints = new GameObject[4];
    [SerializeField]private float rowForce;
    private Vector3[] _floatPoints = new Vector3[4];
    [SerializeField]private GameObject[] movers;
    
    private float _maxDelta = 1;
    private float _lDelta = 0;
    private float _rDelta = 0;
    

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
    
    private void Update()
    {
        CheckInput();
    }

    protected override void FixedUpdate()
    {
        GetFloatPoints();
        base.FixedUpdate();

    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(0,-transform.forward * rowForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(1,-transform.forward * rowForce);
        }

    }

    void Move(int mover, Vector3 force)
    {
        Rb.AddForceAtPosition(force,movers[mover].transform.position);

    }

    public void KickBack(Vector3 point, Vector3 dir, float mag)
    {
        Rb.AddForceAtPosition(dir.normalized * mag ,point);
    }

    void GetFloatPoints()
    {
        for (int i = 0; i < floatPoints.Length; i++)
        {
            _floatPoints[i] = floatPoints[i].transform.position;
        }
    }
}
