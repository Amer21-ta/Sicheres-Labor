using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}

public class QuizManager : MonoBehaviour
{
    public Question[] questions;
    private int currentQuestionIndex = 0;
    private int score = 0;
    
    // UI Referenzen
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text feedbackText;
    public GameObject quizPanel;
    public GameObject resultPanel;
    public GameObject winPanel;  // Das neue WinPanel
    
    // Button im WinPanel
    public Button nextLevelButton;
    public Button restartWinButton;
    
    // Name der nächsten Scene (im Inspector setzen!)
    public string nextSceneName = "MainScene"; // ← HIER DEN NAMEN ÄNDERN!
    
    void Start()
    {
        ShowQuestion(currentQuestionIndex);
        feedbackText.text = "";
        winPanel.SetActive(false); // WinPanel verstecken
        resultPanel.SetActive(false);
    }
    
    void ShowQuestion(int index)
    {
        if (index >= questions.Length)
        {
            CheckWinCondition();
            return;
        }
        
        Question currentQuestion = questions[index];
        questionText.text = (index + 1) + ". " + currentQuestion.questionText;
        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = currentQuestion.answers[i];
                }
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
        
        feedbackText.text = "";
    }
    
    public void OnAnswerSelected(int answerIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        
        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
            feedbackText.text = "Richtig!";
            feedbackText.color = Color.green;
            score++;
        }
        else
        {
            feedbackText.text = "Falsch!";
            feedbackText.color = Color.red;
        }
        
        // Buttons deaktivieren
        foreach (Button btn in answerButtons)
        {
            btn.interactable = false;
        }
        
        StartCoroutine(NextQuestionAfterDelay());
    }
    
    IEnumerator NextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        
        currentQuestionIndex++;
        
        if (currentQuestionIndex < questions.Length)
        {
            // Buttons wieder aktivieren
            foreach (Button btn in answerButtons)
            {
                btn.interactable = true;
            }
            
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            CheckWinCondition();
        }
    }
    
    void CheckWinCondition()
    {
        quizPanel.SetActive(false);
        
        if (score == questions.Length)
        {
            // GEWONNEN - zeige WinPanel
            ShowWinPanel();
        }
        else
        {
            // Verloren - zeige ResultPanel
            ShowResultPanel();
        }
    }
    
    void ShowWinPanel()
    {
        winPanel.SetActive(true); // WinPanel wird sichtbar!
        
        // Debug Log
        Debug.Log("GEWONNEN! WinPanel aktiviert. Nächste Scene: " + nextSceneName);
    }
    
    void ShowResultPanel()
    {
        resultPanel.SetActive(true);
    }
    
    // WICHTIG: Diese Methode lädt die NEUE SCENE
    public void LoadNextScene()
    {
        Debug.Log("Lade nächste Scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
    
    public void RestartQuiz()
    {
        // Quiz zurücksetzen
        currentQuestionIndex = 0;
        score = 0;
        
        // Panels zurücksetzen
        winPanel.SetActive(false);
        resultPanel.SetActive(false);
        quizPanel.SetActive(true);
        
        // Buttons aktivieren
        foreach (Button btn in answerButtons)
        {
            btn.interactable = true;
        }
        
        // Erste Frage zeigen
        ShowQuestion(0);
    }
}