using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50;
    public GameObject DamageText;
    private void OnEnable()
    {
        //CollisionController.CollisionEvent += TakeDamage;
    }

    public void TakeDamage(float amount)
    {
        DamageText.GetComponent<Text>().rectTransform.localPosition = gameObject.transform.position;

        DamageText.GetComponent<Text>().color = health > 30 ? Color.blue : Color.red;

        health -= amount;

        DamageText.GetComponent<Text>().text = health > 0 ? health.ToString():"";
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
