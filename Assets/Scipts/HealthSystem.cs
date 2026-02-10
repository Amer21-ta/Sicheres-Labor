using UnityEngine;
using UnityEngine.UI; // Wichtig für die Slider-Komponente

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Verhindert Werte unter 0
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Spieler ist tot!");
            // Hier kannst du deine EndGame-Logik von vorhin einbauen
        }
    }
}