using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]const int initialXp = 4;
    [SerializeField]const int initialMoney = 10;
    [SerializeField]private LayerMask lmPlayer;

    [SerializeField]private GameObject objCanvas;

    [SerializeField]private Animator animator;

    [SerializeField]private bool isDead;
    [SerializeField]private int xp;
    [SerializeField]private int money;


    RaycastHit hit;

    public int Xp { get => xp;}
    public int Money { get => money;}

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        objCanvas = GetComponentInChildren<Canvas>(true).gameObject;
        isDead = false;
        xp = initialXp;
        money = initialMoney;
    }


    private void FixedUpdate()
    {
        if (!isDead)
        {
            return;
        }
            
    }
    public void TakeHit(Transform point, float force, Transform punch){
        animator.enabled = false;
        Debug.Log(point.name);
        point.GetComponent<Rigidbody>().AddForce(punch.transform.forward * force, ForceMode.Impulse);
        StartCoroutine(CapturedTime());
    }


    IEnumerator CapturedTime(){
        // esperar 1.5 sec para que o inimigo possa ser capturado
        yield return new WaitForSeconds(1);

        isDead = true;
        animator.SetBool("isDead",isDead);
        objCanvas.SetActive(true);
    }
    public bool Captured(Collider other){
        Pile pileScript = other.GetComponent<Pile>();
        if (pileScript.isFull())
        {
            return false;
        }
        SetRigidBody(true);
        pileScript.StackUp(this.gameObject);
        objCanvas.SetActive(false);
        return true;
    }

    public void SetRigidBody(bool flag){

        animator.enabled = flag;
        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigids)
        {
            body.isKinematic = flag;
        }
    }
}
        

