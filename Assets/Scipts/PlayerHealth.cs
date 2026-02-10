using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public Scrollbar HealthScroll;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        HealthScroll.size = Health/100;

        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Spieler ist tot!");
        // Hier Code für Spieler-Tod (z.B. Respawn, Game Over)
    }

  
}
