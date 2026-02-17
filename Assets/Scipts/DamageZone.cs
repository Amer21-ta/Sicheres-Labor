using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float radius = 3f;
    public float damagePerSecond = 20f;

    Transform cam;
    PlayerHealth health;

    void Start()
    {
        cam = Camera.main.transform;
        health = Camera.main.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float d = Vector3.Distance(transform.position, cam.position);

        if (d < radius)
        {
            health.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}