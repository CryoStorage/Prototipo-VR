using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimToggle : MonoBehaviour
{
    private List<Rigidbody> _rigidbodies;
    private List<Collider> _colliders;

    private Rigidbody _charRb;
    private Collider _charCollider;
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }
    
    void Prepare()
    {
        if (_charCollider != null) return;
        try
        {
            _charCollider = GetComponent<Collider>();
        }
        catch { Debug.LogWarning("Could not find _charCollider");}
        
        if (_charRb != null) return;
        try
        {
            _charRb = GetComponent<Rigidbody>();
        }
        catch { Debug.LogWarning("Could not find _charCollider");}
        
        MakeLists();
    }

    void MakeLists()
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            if (item.gameObject != this)
            {
                _rigidbodies.Add(item);
                item.isKinematic = true;
                item.useGravity = false;
            }
            
        }        
        foreach (var item in GetComponentsInChildren<Collider>())
        {
            if (item.gameObject != this)
            {
                _colliders.Add(item);
                item.enabled = false;
            }
        }

        _charCollider.enabled = true;
        _charRb.isKinematic = true;
        _charRb.useGravity = false;
    }

    void Toggle()
    {
        
    }

    
    
}
