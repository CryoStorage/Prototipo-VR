using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Crawl : MonoBehaviour
{
    bool l = false;
    bool r = true;
    Vector3 dir;
    [SerializeField]float speed;
    [SerializeField]GameObject hand;
    CharacterController con;
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
        ChangeHand();

        // Debug.Log(l);
        // Debug.Log(r);

        Debug.Log(dir);
    }

    void Crawl()
    {
        if(Input.GetMouseButtonDown(0) && l == true)
        {
            dir +=(transform.forward * speed * Time.fixedDeltaTime);
            l = false;
            r = true;
        }
        if(Input.GetMouseButtonDown(1) && r == true)
        {
            dir += (transform.forward * speed * Time.fixedDeltaTime);
            r = false;
            l = true;
        }
    }

    void ChangeHand()
    {
        Vector3 rightHand = new Vector3(0.437000006f,-0.0992299914f,0.57099998f);
        
        Vector3 leftHand = new Vector3(-0.437000006f,-0.0992299914f,0.57099998f);
        if(r)
        {
            hand.transform.localPosition = rightHand;

        }else
        {
            hand.transform.localPosition = leftHand;

        }

    }

    void Move()
    {
        Vector3 friction = ((dir ) / 2);  
        dir -= friction * Time.fixedDeltaTime;
        con.Move(dir);

    }
}
