using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Pile : MonoBehaviour
{
    [Header("ATRIBUTO INSPECTOR")]
    [SerializeField]private Transform pivot;
    [SerializeField]private Stack<GameObject> stackedEnemies;


    public static event Action OnUnstackEnemy;



    public Vector2 direcaoBalanca = new Vector2(1f, 1f);
    float directionZ;
    public float force = 5;
    [SerializeField]private float rotationSpeed = 20f;
    private Quaternion targetRotation;





    void Start()
    {
        stackedEnemies = new Stack<GameObject>();
    }

    public bool isFull(){
        return !(stackedEnemies.Count < GameManager.instance.UserData.MaxStack);
    }
    public bool isEmpty(){
        return stackedEnemies.Count <= 0;
    }

    public void StackUp(GameObject enemy){
        
        enemy.transform.position = new Vector3(0, stackedEnemies.Count * .5f, 0) + pivot.position;
        enemy.transform.SetParent(pivot);
        stackedEnemies.Push(enemy);
    }

    public void Unstack(){
        if (isEmpty())
        return;

        OnUnstackEnemy?.Invoke();

        GameObject objEnemy = stackedEnemies.Pop();
        Enemy enemy = objEnemy.GetComponent<Enemy>();
        enemy.SetRigidBody(false);
        objEnemy.transform.position += Vector3.right * 1.35f;  // um pequeno deslocamento pra frente
        objEnemy.transform.SetParent(null);

        GameManager.instance.addMoney(enemy.Money);
        GameManager.instance.AddXp(enemy.Xp); 
    }





    // Tentativa falha de fazer o sistema de inércia
    // void FixedUpdate()
    // {
        
    //     if(stackedEnemies.Count <0) return;

    //     foreach (GameObject obj in stackedEnemies)
    //     {
            
    //         // float distancia = Vector3.Distance(obj.transform.position, pivot.position);
    //         // //float forca = windStrength / distancia;
    //         // Quaternion targetRotation = Quaternion.Euler(
    //         //     obj.transform.rotation.x,
    //         //     obj.transform.rotation.y,
    //         //     directionZ* 15);

    //         // obj.transform.rotation = Quaternion.Lerp( 
    //         //     obj.transform.rotation,
    //         //     targetRotation,
    //         //     force * Time.fixedDeltaTime);
    //     }
    // }

    // void OnMovement(InputValue value){
    //     directionZ = value.Get<Vector2>().y;
    // }
}
