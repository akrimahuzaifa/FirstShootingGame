using System;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject DamageText;

    HealthBar healthBar;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {

            healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
            
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        DamageText.GetComponent<Text>().rectTransform.localPosition = gameObject.transform.position;
        DamageText.GetComponent<Text>().color = currentHealth > 30 ? Color.blue : Color.red;

        currentHealth -= damage;
      
        healthBar.SetHealth(currentHealth);

/*        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);*/

        DamageText.GetComponent<Text>().text = currentHealth > 0 ? currentHealth.ToString() : "";
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
