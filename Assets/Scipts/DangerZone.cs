using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public int damage = 10; // Schaden pro Intervall
    public float damageInterval = 1f; // Zeit zwischen Schadensereignissen
    private bool playerInZone = false;
    private GameObject player;
    private PlayerHealth playerHealth; // Angenommen, der Spieler hat ein Health-Skript

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            player = other.gameObject;
            playerHealth = player.GetComponent<PlayerHealth>();
            StartCoroutine(DealDamageOverTime());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            StopAllCoroutines();
        }
    }

    System.Collections.IEnumerator DealDamageOverTime()
    {
        while (playerInZone && playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}