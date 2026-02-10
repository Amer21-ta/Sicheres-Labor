using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das Objekt, das eintritt, die HealthSystem-Komponente hat
        HealthSystem playerHealth = other.GetComponent<HealthSystem>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
