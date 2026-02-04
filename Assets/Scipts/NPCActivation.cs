using UnityEngine;

public class NPCActivation : MonoBehaviour
{
    public GameObject npcToActivate; // Ziehe hier deinen NPC im Inspector rein

    private void OnTriggerEnter(Collider other)
    {
        // Prüft, ob das Objekt, das den Trigger berührt, den Tag "Player" hat
        if (other.CompareTag("Player"))
        {
            npcToActivate.SetActive(true); // Aktiviert den NPC
            Debug.Log("NPC wurde aktiviert!");
        }
    }
}
