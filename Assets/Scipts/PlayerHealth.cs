using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    // Health Bar UI
    public Slider healthSlider;
    public Image fillImage;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        Debug.Log("✅ PlayerHealth gestartet");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        Debug.Log("❤️ Health: " + currentHealth);
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Debug.Log("💀 PLAYER GESTORBEN!");
        }
    }
    
    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
        
        if (fillImage != null)
        {
            float percent = currentHealth / maxHealth;
            if (percent > 0.6f)
                fillImage.color = Color.green;
            else if (percent > 0.3f)
                fillImage.color = Color.yellow;
            else
                fillImage.color = Color.red;
        }
    }
}