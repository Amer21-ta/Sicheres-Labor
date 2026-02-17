using UnityEngine;

public class NPCProximityVoice : MonoBehaviour
{
    public float talkDistance = 3f;

    AudioSource audioSrc;
    Transform playerCam;

    bool wasInRange = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        playerCam = Camera.main.transform;
    }

    void Update()
    {
        float d = Vector3.Distance(transform.position, playerCam.position);

        bool inRange = d < talkDistance;

        // Player kommt NEU rein
        if (inRange && !wasInRange)
        {
            audioSrc.Play();
        }

        // Player geht raus
        if (!inRange && wasInRange)
        {
            audioSrc.Stop();
        }

        wasInRange = inRange;
    }
}