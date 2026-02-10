using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleDialogue : MonoBehaviour
{
    // UI Elemente
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button continueButton;
    
    // Dialog-Zeilen
    public string[] messages = {
        "Hallo!",
        "Wie geht es dir?",
        "Schön dich zu sehen!",
        "Das ist der letzte Text",
        "Und jetzt geht's von vorne los!"
    };
    
    private int currentMessage = 0;
    
    void Start()
    {
        // Panel sichtbar
        dialoguePanel.SetActive(true);
        
        // Erste Nachricht anzeigen
        ShowMessage();
        
        // Button Event
        continueButton.onClick.AddListener(NextMessage);
        
        // Button Text anpassen
        continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Weiter";
    }
    
    void ShowMessage()
    {
        dialogueText.text = messages[currentMessage];
        
        // OPTIONAL: Im Inspector die aktuelle Position anzeigen
        // z.B. "Text 1/5"
    }
    
    void NextMessage()
    {
        currentMessage++;
        
        // Wenn letzte Nachricht erreicht, wieder von vorne beginnen
        if (currentMessage >= messages.Length)
        {
            currentMessage = 0; // Reset auf Anfang
            Debug.Log("Dialog startet von vorne!");
        }
        
        ShowMessage();
    }
    
    // OPTIONAL: Tastatur-Steuerung hinzufügen
    void Update()
    {
        // Leertaste drücken für nächste Nachricht
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }
}