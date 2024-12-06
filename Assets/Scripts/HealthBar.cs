using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    [Header("Slider Information")]
    [SerializeField] Slider slider; 
    
    public void updateHealthBar(double damage)
    {
        //Debug.Log("Damage: " + damage);
        float value = (float)damage; 
        slider.value -= value;
    }
}
