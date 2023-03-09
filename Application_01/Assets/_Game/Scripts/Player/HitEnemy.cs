using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class HitEnemy : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private CapsuleCollider capsuleCollider;

    [SerializeField]private float force = 300;
    WaitForSeconds enableTime = new WaitForSeconds(0.4f);


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
        target = null;
    }
    void OnTriggerEnter(Collider other)
    {
        if (target!= null)
        {
            return;
        }
        target = other.transform;
        other.GetComponentInParent<Enemy>().TakeHit(target,force, transform);

    }

    void OnPunch(){
        StartCoroutine(enableTrigger());
    }

    IEnumerator enableTrigger(){
        capsuleCollider.enabled = true;
        yield return enableTime;
        capsuleCollider.enabled = false;
        target = null;
    }
}
