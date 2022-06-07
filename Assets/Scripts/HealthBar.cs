using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static event Action<HealthBar> OnHealthAdded = delegate { };
    public static event Action<HealthBar> OnHealthREmoved = delegate { };

    public Slider slider;

    private void Awake()
    {
        //GetComponentInParent<Target>().OnHealthPctChanged += 
        // slider.value = Mathf.Lerp(slider.value, 0f, 0.1f * Time.deltaTime);
        slider.value = 80;

    }

    private void Update()
    {
      
    }

    void HandleHealthChanged(float pct)
    {

    }

/*    IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = 
    }*/

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    public void SetHealth(float health)
    {
        slider.value =  health;
    }
}
