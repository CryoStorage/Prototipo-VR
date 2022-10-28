using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Canon_CanonBall : MonoBehaviour
{
    private Rigidbody _rb;
    private MeshRenderer _rend;
    private Collider _col;
    private Debug_CannonFire _cannonFire;
    
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    private void Deactivate()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _rend.enabled = false;
        _col.enabled = false;
        _cannonFire.Reload(this);

    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        Explode();
        Debug.Log(gameObject.name+" Exploded");
    }

    private void Activate()
    {
        _rb.isKinematic = false;
        _rend.enabled = false;
        _col.enabled = false;
        
    }

    public void Fire(Vector3 origin,Vector3 dir, float mag)
    {
        transform.position = origin;
        Activate();
        _rb.AddForce(dir.normalized * mag);

    }

    void Explode()
    {
        Deactivate();
    }

    private void Prepare()
    {
        try
        {
            _rb = GetComponent<Rigidbody>();
        }
        catch { Debug.Log("Missing RigidBody");}
        try
        {
            _rend = GetComponentInChildren<MeshRenderer>();
        }
        catch { Debug.Log("Missing MeshRenderer");}
        try
        {
            _col = GetComponent<Collider>();
        }
        catch { Debug.Log("Missing Collider");}
    }
}
