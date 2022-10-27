using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Handle : MonoBehaviour
{

    [SerializeField] private GameObject cannon;

    [SerializeField] private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     LookAtCannon();
     LimitPosition();
    }

    private void LimitPosition()
    {
        
        Vector3 limited = (transform.position - cannon.transform.position).normalized * maxDistance;
        Vector3 limitX = new Vector3();
        Vector3 limitY = new Vector3();
        Vector3 limitZ = new Vector3();
        transform.position = new Vector3(limited.x, limited.y, limited.z);

    }

    private void LookAtCannon()
    {
        transform.LookAt(cannon.transform.position);
        
    }
}
