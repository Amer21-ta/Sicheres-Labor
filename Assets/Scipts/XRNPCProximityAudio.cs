using UnityEngine;
using UnityEngine;

public class XRNPCProximityAudio : MonoBehaviour
{
    public AudioSource voice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            if (!voice.isPlaying)
                voice.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            voice.Stop();
        }
    }
}