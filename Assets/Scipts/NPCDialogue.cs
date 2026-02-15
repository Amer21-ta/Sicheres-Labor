using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInRange)
        {
            playerInRange = true;
            Speak();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerInRange)
        {
            playerInRange = false;
            StopSpeaking();
        }
    }

    void Speak()
    {
        Debug.Log("NPC spricht: Hallo!");
        // Hier kannst du Audio oder UI Text abspielen
    }

    void StopSpeaking()
    {
        Debug.Log("NPC stoppt das Sprechen.");
        // Audio stoppen oder Text ausblenden
    }
    
}