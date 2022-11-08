using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCannon : Debug_CannonFire
{
    private Boat _boat;

    protected override void Launch()
    {
        try
        {
            Canon_CanonBall current = CanonBalls.Dequeue();
            current.Fire(transform.position,transform.forward,launchForce);
            _boat.KickBack(transform.position, -transform.forward, 50);
        }
        catch { Debug.Log("Queue Is empty"); }
    }

    protected override void Prepare()
    {
        base.Prepare();
        try
        {
            _boat = GetComponentInParent<Boat>();
        }
        catch { Debug.Log("Missing Boat"); }

    }
}
