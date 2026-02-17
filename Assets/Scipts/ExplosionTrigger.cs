using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public ParticleSystem explosion;
    public float triggerDistance = 3f;

    Transform playerCam;
    bool exploded = false;

    void Start()
    {
        playerCam = Camera.main.transform;
    }

    void Update()
    {
        if (exploded) return;

        float d = Vector3.Distance(transform.position, playerCam.position);

        if (d < triggerDistance)
        {
            Debug.Log("BOOM");
            explosion.Play();
            exploded = true;
        }
    }
}