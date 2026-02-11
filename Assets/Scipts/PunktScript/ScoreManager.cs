using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    
    void Start()
    {
        // Event hören
        GameEvents.OnAddScore += AddScore;
        UpdateUI();
    }
    
    void AddScore(int points)
    {
        score += points;
        UpdateUI();
        Debug.Log("+" + points + " Punkte! Total: " + score);
    }
    
    void UpdateUI()
    {
        if (scoreText) scoreText.text = "Punkte: " + score;
    }
    
    void OnDestroy()
    {
        GameEvents.OnAddScore -= AddScore;
    }
}