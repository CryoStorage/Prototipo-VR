using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class ActiveRagdoll : MonoBehaviour
{
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private GameObject reference;
    
    private List<ConfigurableJoint> _configurableJoints;
    private List<Transform> _referenceJoints;
    private List<Quaternion> _referenceQuaternions;

    private int _health = 5;
    private Animator _anim;
    private bool _cooledDown = true;
    private bool _randomized;

    // Start is called before the first frame update
    private void Start()
    {
        BuildLists();
        Prepare();
        
        
    }

    private void Update()
    {
        OnPlayerHit();
    }

    public void TakeDamage()
    {
        if (!_cooledDown) return;
        _health--;
        StartCoroutine(DmgCooldown());


    }

    private IEnumerator DmgCooldown()
    {
        _cooledDown = false;
        yield return new WaitForSeconds(1f);
        _cooledDown = true;

    }

    private void OnPlayerHit()
    {
        switch (_health)
        {
            case 5:
                _anim.Play("Offensive Idle");
                break;
            case 4:
                _anim.Play("Fighting Idle");
                break;
            case 3:
                _anim.Play("Hit To Body");
                break;
                case 2:
                _anim.Play("Kidney Hit");
                break;
                case 1:
                    _anim.Play("Knocked Out");
                break;
                case 0:
                    PlayDeath();
                    _anim.enabled = false;
                    break;
        }
 
    }

    // private void PlayHit()
    // {
    //     if(_randomized)return;
    //     int r = Random.Range(0, 3);
    //     Debug.LogWarning(r);
    //     switch (r)
    //     {
    //         case 0:
    //         _anim.Play("Hit Reaction(1)");
    //         _randomized = true;
    //             break;
    //         case 1:
    //             _anim.Play("Hit Reaction");
    //         _randomized = true;
    //             break;
    //         case 2:
    //             _anim.Play("Kidney Hit");
    //         _randomized = true;
    //             break;
    //         case 3:
    //             _anim.Play("Hit To Body");
    //         _randomized = true;
    //             break;
    //     }
    // }
    // private void PlayBigHit()
    // {
    //     if(_randomized)return;
    //     int r = Random.Range(0, 2);
    //     
    //     Debug.LogWarning(r);
    //     switch (r)
    //     {
    //         case 0:
    //             _anim.Play("Hit Reaction(1)");
    //             _randomized = true;
    //             break;
    //         case 1:
    //             _anim.Play("Hit Reaction");
    //             _randomized = true;
    //             break;
    //         case 2:
    //             _anim.Play("Kidney Hit");
    //             _randomized = true;
    //             break;
    //     }
    //
    // } 

    private void PlayDeath()
    {
        int r = Random.Range(0, 2);
        switch (r)
        {
            case 0:
                _anim.Play("Knocked Out");
                break;
            case 1:
                _anim.Play("Dying");
                break;
            case 2:
                _anim.Play("Zombie Stumbling");
                break;
            
        }
        
    }

    private void BuildLists()
    {
        _configurableJoints = new List<ConfigurableJoint>();
        _referenceJoints = new List<Transform>();
        _referenceQuaternions = new List<Quaternion>();
        foreach (var item in ragdoll.GetComponentsInChildren<ConfigurableJoint>())
        {
            _configurableJoints.Add(item);
            item.gameObject.AddComponent<CollisionDetection>();
        }
        foreach (var item in reference.GetComponentsInChildren<Transform>())
        {
            for (int i = 0; i < _configurableJoints.Count; i++)
            {
                if (item.name == _configurableJoints[i].name)
                {
                    _referenceJoints.Add(item);
                    _referenceQuaternions.Add(item.transform.localRotation);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < _configurableJoints.Count; i++)
        {
            _configurableJoints[i].targetRotation = Quaternion.Inverse(_referenceJoints[i].localRotation) * _referenceQuaternions[i]; 
        }
        
    }

    void Prepare()
    {
        if (_anim != null) return;
        try
        {
            _anim = reference.GetComponent<Animator>();
        }
        catch { Debug.LogWarning("Could not find Animator in reference");}
        
    }
}
