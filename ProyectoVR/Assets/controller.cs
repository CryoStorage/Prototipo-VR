using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    private CharacterController _controller;

    private Vector3 dir = new Vector3(0,0,0);
    private Vector3 gravity;

    [SerializeField] private float grav;

    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
      gravity = new Vector3(0,-grav,0);
        try
        {
            _controller = GetComponent<CharacterController>();
        }
        catch { Debug.LogWarning("Missing CharacterController");}
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-speed, 0, 0) * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        _controller.Move(dir);
        CheckInput();
    }

    void ApplyGravity()
    {
        dir += gravity * Time.fixedDeltaTime;

    }
}
