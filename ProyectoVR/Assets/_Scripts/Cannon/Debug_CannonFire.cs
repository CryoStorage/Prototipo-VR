using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Debug_CannonFire : MonoBehaviour
{
    [Tooltip("Object Fired by the cannon")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private int maxProjectiles;
    [SerializeField] protected float launchForce = 800f;
    
    protected Queue<Canon_CanonBall> CanonBalls;
    private int _current;

    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    { 
        CheckInput();   
    }

    private void CheckInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Launch();
    }

    protected virtual void Launch()
    {
        try
        {
            Canon_CanonBall current = CanonBalls.Dequeue();
            current.Fire(transform.position,transform.forward,launchForce);
        }
        catch { Debug.Log("Queue Is empty"); }
    }

    public void Reload(Canon_CanonBall canonBall)
    {
        try
        {
            CanonBalls.Enqueue(canonBall);
        }
        catch { Debug.Log("Error Queuing");}
    }
    private void BuildPool()
    {
        CanonBalls = new Queue<Canon_CanonBall>();
        for (int i = 0; i < maxProjectiles; i++)
        {
            GameObject temp = Instantiate(projectile);
            temp.name = "CanonBall " + i;
            temp.GetComponent<Canon_CanonBall>().cannonFire = this;
            CanonBalls.Enqueue(temp.GetComponent<Canon_CanonBall>());
        }    
    }

    protected virtual void Prepare()
    {
        BuildPool();
        
    }
}