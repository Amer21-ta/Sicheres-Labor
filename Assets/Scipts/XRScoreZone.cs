using UnityEngine;
using TMPro;
using System.Collections.Generic;  // Wichtig für HashSet!

public class XRScoreZone : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    
    // Das ist die ganze Zauberei - nur eine Zeile!
    private HashSet<GameObject> scoredObjects = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        // Nur 3 Bedingungen:
        // 1. Richtiger Tag? 
        // 2. Noch nicht im HashSet?
        if (other.CompareTag("XRObject") && !scoredObjects.Contains(other.gameObject))
        {
            scoredObjects.Add(other.gameObject);  // Objekt merken
            score += 10;                          // Punkte geben
            scoreText.text = "Score: " + score;   // Anzeige updaten
        }
    }
}