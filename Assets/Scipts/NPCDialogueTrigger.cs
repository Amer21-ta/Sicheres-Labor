using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip dialogueSound;     // Der Sound, der abgespielt wird
    public AudioSource audioSource;     // Referenz zur AudioSource
    
    [Header("Detection Settings")]
    public float detectionRange = 3f;   // Reichweite für die NPC-Erkennung
    public Transform player;            // Referenz zum Spieler
    
    private bool isPlayerInRange = false;
    private bool wasPlayerInRange = false;  // Für Zustandswechsel-Erkennung

    void Start()
    {
        // Falls keine AudioSource zugewiesen, versuche eine zu finden oder füge eine hinzu
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        
        // AudioSource Einstellungen
        audioSource.clip = dialogueSound;
        audioSource.loop = false;        // Nicht loopen, damit der Sound immer wieder neu startet
        audioSource.playOnAwake = false;
        
        // Falls Spieler nicht zugewiesen, versuche ihn zu finden
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return;
        
        // Berechne Distanz zum Spieler
        float distance = Vector3.Distance(transform.position, player.position);
        isPlayerInRange = distance <= detectionRange;
        
        // Prüfe auf Zustandsänderung
        if (isPlayerInRange && !wasPlayerInRange)
        {
            // Spieler kommt in Reichweite
            PlayDialogue();
        }
        else if (!isPlayerInRange && wasPlayerInRange)
        {
            // Spieler verlässt Reichweite
            StopDialogue();
        }
        
        // Aktualisiere vorherigen Zustand
        wasPlayerInRange = isPlayerInRange;
    }
    
    void PlayDialogue()
    {
        if (dialogueSound != null)
        {
            audioSource.Play();
            Debug.Log("NPC beginnt zu sprechen");
        }
    }
    
    void StopDialogue()
    {
        audioSource.Stop();
        Debug.Log("NPC hört auf zu sprechen");
    }
    
    // Optional: Visualisiere die Reichweite im Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}