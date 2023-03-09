using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("ATRIB. INSPECTOR")]
    [SerializeField]private UserData userData;

    [Header("ATRIB. CLASSE")]
    [SerializeField]private float rotationSpeed = 20f;
    [SerializeField]private Vector3 direction;
    [SerializeField]private float speed;
    void Start()
    {
        speed = userData.Speed;
    }

    void FixedUpdate()
    {
        transform.position +=  direction * speed * Time.fixedDeltaTime;
        
        if (direction.magnitude == 0){
            return;
        }
        
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    public void OnMovement(InputValue value){
        
        Vector2 movement = value.Get<Vector2>();
        direction = new Vector3(movement.x,0,movement.y);
        //if (direction.magnitude > 1f) direction.Normalize();
    }
}
