using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField]private float time;
    [SerializeField]private float cooldown;
    void Start()
    {
        cooldown = 1.5f;
        time = cooldown;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        time -= Time.fixedDeltaTime;

        if (time <= 0)
        {
            time = cooldown;
            other.GetComponent<Pile>().Unstack();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
            
        time = cooldown;
    }
}
