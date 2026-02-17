using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float damageAmount = 30f;
    public float damageRadius = 5f;

    public void DealDamage()
    {
        Debug.Log("💥 Damage Zone aktiv!");
        
        // Finde Player Health Component
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        
        if (playerHealth != null)
        {
            // Distanz prüfen
            float distance = Vector3.Distance(transform.position, playerHealth.transform.position);
            Debug.Log("Distanz zum Player: " + distance);
            
            if (distance <= damageRadius)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("🔥 Schaden zugefügt: " + damageAmount);
            }
            else
            {
                Debug.Log("👎 Player zu weit weg: " + distance + " > " + damageRadius);
            }
        }
        else
        {
            Debug.LogError("❌ PlayerHealth nicht gefunden!");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, damageRadius);
    }
}