using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public AudioSource audioSource;
    public float range = 5f;
    public Transform player;
    
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        
        if (dist <= range && !audioSource.isPlaying)
            audioSource.Play();
        else if (dist > range && audioSource.isPlaying)
            audioSource.Stop();
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}