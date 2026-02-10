using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Scrollbar healthBar;  // Scrollbar statt Slider!
    
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            // Scrollbar value geht von 0 bis 1
            healthBar.size = currentHealth / maxHealth;
        }
    }
    
    void Die()
    {
        Debug.Log("Player gestorben!");
        // Hier: Game Over Logic
    }
}