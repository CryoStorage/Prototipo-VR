using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Crawl : MonoBehaviour
{
    bool l = false;
    bool r = true;
    Vector3 dir;
    [SerializeField]float speed;
    CharacterController con;
    Vector3 friction;
    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Crawl();
        Move();

        Debug.Log(l);
        Debug.Log(r);
    }

    void Crawl()
    {
        if(Input.GetMouseButtonDown(0) && l == true)
        {
            dir +=(Vector3.forward * speed * Time.fixedDeltaTime);
            l = false;
            r = true;
        }
        if(Input.GetMouseButtonDown(1) && r == true)
        {
            dir += (Vector3.forward * speed * Time.fixedDeltaTime);
            r = false;
            l = true;
        }
    }

    void Move()
    {
        friction = ((dir * -1) / 10);  
        con.Move(dir);

    }
}
