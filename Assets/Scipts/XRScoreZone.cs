using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class XRScoreZone : MonoBehaviour
{
    public int score = 0;
    public int winScore = 1000;

    public TextMeshProUGUI scoreText;
    public AudioSource winSound;

    private HashSet<GameObject> scoredObjects = new HashSet<GameObject>();
    bool won = false;

    void Start()
    {
        // Falls schon gespeichert (z.B. nach Restart)
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (won) return;

        if (other.CompareTag("XRObject") && !scoredObjects.Contains(other.gameObject))
        {
            scoredObjects.Add(other.gameObject);

            score += 10;
            scoreText.text = "Score: " + score;

            // Score speichern
            PlayerPrefs.SetInt("Score", score);

            if (score >= winScore)
            {
                Win();
            }
        }
    }

    void Win()
    {
        won = true;

        // Finalen Score speichern
        PlayerPrefs.SetInt("FinalScore", score);

        // Sound abspielen
        winSound.Play();

        // Nach 2 Sekunden WinScene laden
        Invoke(nameof(LoadWinScene), 2f);
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}