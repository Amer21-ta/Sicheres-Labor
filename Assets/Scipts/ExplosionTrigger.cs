using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public ParticleSystem feuer;
    public ParticleSystem explosion;
    public AudioSource explosionSound;
    public float triggerDistance = 3f;

    Transform playerCam;
    bool exploded = false;
    bool feuert = false;
    
    // Referenz zum Damage Script
    private ExplosionDamage damageZone;

    void Start()
    {
        playerCam = Camera.main.transform;
        
        // Damage Component holen
        damageZone = GetComponent<ExplosionDamage>();
        
        if (feuer != null) feuer.Stop();
        if (explosion != null) explosion.Stop();
    }

    void Update()
    {
        float d = Vector3.Distance(transform.position, playerCam.position);

        // 🔥 FEUER ZÜNDEN
        if (!feuert && d < triggerDistance * 1.5f)
        {
            Debug.Log("🔥 FEUER!");
            
            if (feuer != null)
            {
                feuer.Play();
                feuert = true;
            }
        }

        // 💥 EXPLOSION
        if (!exploded && d < triggerDistance)
        {
            Debug.Log("💥 BOOM!");
            
            if (explosion != null)
            {
                explosion.Play();
            }
            
            if (explosionSound != null)
            {
                explosionSound.Play();
            }
            
            // 🔥 DAMAGE ZONE aktivieren!
            if (damageZone != null)
            {
                damageZone.DealDamage();
            }
            
            exploded = true;
        }
    }
}