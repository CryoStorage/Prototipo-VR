using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_CannonFire : MonoBehaviour
{
    [Tooltip("Object Fired by the cannon")] 
    [SerializeField] private Rigidbody projectile;

    [SerializeField] private int maxProjectiles;

    [SerializeField] private float launchForce;
    
    private Queue<Canon_CanonBall> _canonBalls;
    private int _current;

    // Start is called before the first frame update
    void Start()
    {
        BuildPool();
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

    private void Launch()
    {
        if (_current == maxProjectiles)
        {
            _current = 0;
        }
        try
        {
            _canonBalls.Dequeue().Fire(transform.position,transform.forward,launchForce);

        }
        catch { Debug.Log("Queue Is empty"); }
    }

    public void Reload(Canon_CanonBall canonBall)
    {
        _canonBalls.Enqueue(canonBall);
        
    }
    private void BuildPool()
    {
        _canonBalls = new Queue<Canon_CanonBall>();
        for (int i = 0; i < maxProjectiles; i++)
        {
            Rigidbody temp = Instantiate(projectile.GetComponent<Rigidbody>());
            _canonBalls.Enqueue(temp.GetComponent<Canon_CanonBall>());
            Debug.Log("Added projectile");
        }    
    }

}
