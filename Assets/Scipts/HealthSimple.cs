using UnityEngine;
using UnityEngine.UI;

public class HealthSimple : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    
    float health = 100f;

    void Start()
    {
        // Prüfen ob Slider da ist
        if (slider == null)
        {
            Debug.LogError("❌ KEIN SLIDER ZUGEWIESEN!");
            return;
        }
        
        // Auf 100% setzen
        slider.value = 1f;
        fill.color = Color.green;
        
        Debug.Log("✅ Health Bar bereit!");
    }

    void Update()
    {
        // Mit Pfeiltasten testen
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            health += 10f;
            health = Mathf.Clamp(health, 0, 100);
            slider.value = health / 100f;
            Debug.Log("Health +: " + health);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            health -= 10f;
            health = Mathf.Clamp(health, 0, 100);
            slider.value = health / 100f;
            
            // Farbe ändern
            if (health > 60)
                fill.color = Color.green;
            else if (health > 30)
                fill.color = Color.yellow;
            else
                fill.color = Color.red;
                
            Debug.Log("Health -: " + health);
        }
    }
}
