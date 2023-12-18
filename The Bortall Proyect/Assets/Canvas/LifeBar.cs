using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider Slider;
   
    private void Start()
    {
       Slider = GetComponent<Slider>(); 
    }

    public void ChangeHPMax(float HPMax){
        Slider.maxValue = HPMax;
    }

    public void ChangeHPActual(float HPAmount){
        Slider.value = HPAmount;
    }

    public void StartLifeBar(float HPAmount){
        ChangeHPMax(HPAmount);
        ChangeHPActual(HPAmount);
    }
}
