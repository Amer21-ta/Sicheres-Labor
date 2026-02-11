using UnityEngine;
using UnityEngine.SceneManagement; // Wichtig für Szenenwechsel/Neustart
using UnityEngine.UI; // Falls du UI-Text anzeigen willst
using System.Collections;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60; // Startzeit in Sekunden
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;  // Zuweisen eines UI-Textfeldes im Inspector

    private void Start()
    {
        // Timer beim Start aktivieren
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Zeit abgelaufen!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (timeText != null)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {

           //Szene neu laden oder GameOver-Panel aktivieren
           SceneManager.LoadScene("GameOverScene");
    }
    
}
