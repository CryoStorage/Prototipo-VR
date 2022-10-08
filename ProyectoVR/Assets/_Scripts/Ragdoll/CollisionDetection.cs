using System;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private ActiveRagdoll _activeRagdoll;

    private void Start()
    {
        Prepare();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        _activeRagdoll.TakeDamage();
    }

    private void Prepare()
    {
        if (_activeRagdoll != null) return;
        try
        {
            _activeRagdoll = GetComponentInParent<ActiveRagdoll>();
        }
        catch { Debug.LogWarning("Could not find ActiveRagdoll in parent");}

    }
    
    
    
    
    
}
