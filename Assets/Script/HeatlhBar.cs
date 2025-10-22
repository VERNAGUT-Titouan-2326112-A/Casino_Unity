using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Collision avec : " + hit.gameObject.name + " (Tag: " + hit.gameObject.tag + ")");

        if (hit.gameObject.CompareTag("Water"))
        {
            Debug.Log(">>> Le joueur est tombé dans l’eau !");
            TakeDamage(20);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.value = currentHealth;
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.value = currentHealth;
    }
}
