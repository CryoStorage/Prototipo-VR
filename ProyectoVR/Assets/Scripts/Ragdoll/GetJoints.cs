using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJoints : MonoBehaviour
{
    private List<ConfigurableJoint> _joints;
    private List<Quaternion> _quaternions;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GetComponentsInChildren<ConfigurableJoint>())
        {
            _joints.Add(item);
            _quaternions.Add(item.transform.localRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
