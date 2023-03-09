using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{
    [Header("ATRIB. Inspect")]
    [SerializeField]private Text txtInfo;
    [Header("ATRIB. GameObject")]
    [SerializeField]private Slider slider;

    [Header("ATRIB. Classe")]
    [SerializeField]private float catchTime;

    void Start()
    {
        catchTime = 0;
        txtInfo.color = Color.white;
        txtInfo.text = "Stay on top to pick up";
        slider = GetComponentInChildren<Slider>(); 
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        catchTime+= Time.fixedDeltaTime;
        slider.value = catchTime;
        if (slider.value >= slider.maxValue){
            if(!GetComponentInParent<Enemy>().Captured(other))
                WarningMessage();
        }
    }

    void WarningMessage(){
        txtInfo.text = "stack limit reached";
        txtInfo.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        txtInfo.text = "Stay on top to pick up";
        txtInfo.color = Color.white;
        slider.value = 0;
        catchTime = 0;
    }
}
