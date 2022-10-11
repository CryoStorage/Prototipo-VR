using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkTorso : MonoBehaviour
{
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    private Vector3 _handsLine;

    void Update()
    {

        Vector3 PlanarRightHand = new Vector3(rightHand.transform.position.x, 0, rightHand.transform.position.z);
        Vector3 PlanarLeftHand = new Vector3(leftHand.transform.position.x, 0, leftHand.transform.position.z);
        _handsLine = PlanarRightHand - PlanarLeftHand;
        Debug.DrawRay(PlanarLeftHand,_handsLine, Color.magenta);
        Vector3 chestForward = transform.position + new Vector3(0, 0, 1);
        Debug.DrawLine(transform.position, chestForward , Color.cyan);
        transform.LookAt(transform.position - (_handsLine * .5f));
        
        


    }
    
}
