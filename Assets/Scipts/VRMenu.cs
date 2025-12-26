// 26.12.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class VRMenuController : MonoBehaviour
{
    public void OnStartGame()
    {
        // Spiel starten
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void OnQuitGame()
    {
        // Spiel beenden
        Application.Quit();
        Debug.Log("Spiel beendet");
    }
    public GameObject optionsPanel; // Referenz zum OptionsPanel

    public void OnOptions()
   {
      Debug.Log("Optionen geöffnet");
      optionsPanel.SetActive(true); // Aktiviert das OptionsPanel
   }
   public void CloseOptions()
   {
     Debug.Log("Optionen geschlossen");
     optionsPanel.SetActive(false); // Deaktiviert das OptionsPanel
   }
}
