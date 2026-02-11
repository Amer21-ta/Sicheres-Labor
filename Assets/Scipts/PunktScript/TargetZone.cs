using UnityEngine;

public class TargetZone : MonoBehaviour
{
    public int points = 10;
    
    void OnTriggerEnter(Collider other)
    {
        // Wenn Objekt mit Tag "Object" die Zone berührt
        if (other.CompareTag("Object"))
        {
            // Event auslösen
            GameEvents.AddScore(points);
            
            // Optional: Objekt grün färben
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}