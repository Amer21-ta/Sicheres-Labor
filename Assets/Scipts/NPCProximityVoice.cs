using UnityEngine;

public class NPCProximityVoice : MonoBehaviour
{
    public float talkDistance = 3f;

    private AudioSource audioSrc;
    private Transform playerCam;
    private bool wasInRange = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        GameObject camObj = GameObject.FindWithTag("MainCamera");
        if (camObj != null)
        {
            playerCam = camObj.transform;
        }
        else
        {
            Debug.LogError("MainCamera not found!");
        }
    }

    void Update()
    {
        if (playerCam == null) return;

        float d = Vector3.Distance(transform.position, playerCam.position);
        bool inRange = d < talkDistance;

        if (inRange && !wasInRange)
        {
            audioSrc.Play();
        }

        if (!inRange && wasInRange)
        {
            audioSrc.Stop();
        }

        wasInRange = inRange;
    }
}
