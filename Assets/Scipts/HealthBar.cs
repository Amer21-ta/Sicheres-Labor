using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    PlayerHealth health;

    void Start()
    {
        health = Camera.main.GetComponent<PlayerHealth>();
        slider.maxValue = health.maxHealth;
    }

    void Update()
    {
        slider.value = health.currentHealth;
    }
}
