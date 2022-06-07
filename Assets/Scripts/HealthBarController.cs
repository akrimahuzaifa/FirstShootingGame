using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBarPrefab;
    private Dictionary<HealthBar, HealthBar> healthBars = new Dictionary<HealthBar, HealthBar>();

    private void Awake()
    {
        
    }

    private void AddHealthBar(HealthBar health)
    {
        if (!healthBars.ContainsKey(health))
        {
            var healthBar = Instantiate(healthBarPrefab, transform);
            healthBars.Add(health, healthBar);
            //healthBar.SetHealth(health);
        }
    }

}
