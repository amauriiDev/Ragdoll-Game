using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    const int IDLE = 0;
    const int RUN = 1;
    [SerializeField]private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void PlayRunAnimation(){
        animator.SetInteger("transition",RUN);
    }
    private void PlayIdleAnimation(){
        animator.SetInteger("transition",IDLE);
    }
    private void PlayPunchAnimation(){
        animator.SetTrigger("tgrPunch");
    }



    private void OnMovement(InputValue value){
        Vector2 run = value.Get<Vector2>();
        if (run != Vector2.zero)
        {
            PlayRunAnimation();
        }
        else{
            PlayIdleAnimation();
        }

    }

    private void OnPunch(){
        PlayPunchAnimation();
    }
}
