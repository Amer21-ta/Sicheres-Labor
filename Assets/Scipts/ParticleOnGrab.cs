using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParticleOnGrab : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Start()
    {
        // Partikelsystem holen
        particleSystem = GetComponent<ParticleSystem>();
        
        // XR Grab Interactable holen
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Events verbinden
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }

        // Partikel am Anfang ausschalten
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (particleSystem != null && !particleSystem.isPlaying)
        {
            particleSystem.Play();
            Debug.Log("Objekt aufgenommen - Partikel gestartet");
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Stop();
            Debug.Log("Objekt losgelassen - Partikel gestoppt");
        }
    }

    private void OnDestroy()
    {
        // Events sauber entfernen
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}