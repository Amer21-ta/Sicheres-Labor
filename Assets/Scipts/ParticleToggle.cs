using UnityEngine;

public class ParticleToggle : MonoBehaviour
{
    public ParticleSystem particles;

    public void ToggleParticles()
    {
        if (particles.isPlaying)
        {
            particles.Stop();
        }
        else
        {
            particles.Play();
        }
    }
}
