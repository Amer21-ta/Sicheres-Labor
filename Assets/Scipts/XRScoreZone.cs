using UnityEngine;
using TMPro;

public class XRScoreZone : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("XRObject"))
        {
            score += 10;
            scoreText.text = "Score: " + score;

            Destroy(other.gameObject);
        }
    }
}
