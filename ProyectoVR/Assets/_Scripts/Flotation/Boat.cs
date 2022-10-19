using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Bouyancy
{
    [SerializeField]private GameObject[] movers;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        movers = new GameObject[movers.Length];
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Move(getForce());
        
    }

    void Move(Vector3 f)
    {
        if (movers.Length == 0) return;
        foreach (var point in movers)
        {
            Rb.AddForceAtPosition(f,point.transform.position,ForceMode.Impulse);
        }
        
    }

    private Vector3 getForce()
    {
        Vector3 result = new Vector3();
        
        return result;
    }
    
    
}
