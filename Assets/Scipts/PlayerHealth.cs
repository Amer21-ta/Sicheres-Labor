using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public AudioSource gameOverSound;

    bool dead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        if (dead) return;

        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        
        Time.timeScale = 1f;

        gameOverSound.Play();

        Invoke(nameof(LoadGameOver), 2f); // 2 Sekunden warten
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("TutScene");
    }
}