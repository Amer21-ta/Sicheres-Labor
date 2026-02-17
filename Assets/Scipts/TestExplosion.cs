using UnityEngine;

public class TestExplosion : MonoBehaviour
{
    public ParticleSystem fx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE GEDRÜCKT");
            fx.Play();
        }
    }
}