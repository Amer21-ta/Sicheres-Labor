using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkingTopRightTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float gameTime = 300f; // 5 Minuten
    
    [Header("Position Settings")]
    [SerializeField] private float rightOffset = 20f;
    [SerializeField] private float topOffset = 50f;
    [SerializeField] private float width = 250f;
    [SerializeField] private float height = 70f;
    [SerializeField] private int fontSize = 60;
    
    // Private Variablen
    private Text timerText;
    private float currentTime;
    private bool timerRunning = true;

    void Start()
    {
        // 1. Timer UI erstellen
        CreateTimerUI();
        
        // 2. Timer starten
        currentTime = gameTime;
        UpdateDisplay();
        StartCoroutine(TimerCountdown());
    }

    void CreateTimerUI()
    {
        Debug.Log("Erstelle Timer UI...");
        
        // Canvas suchen oder erstellen
        Canvas canvas = GetCanvas();
        
        // TimerText GameObject erstellen
        GameObject textObject = new GameObject("TimerDisplay");
        textObject.transform.SetParent(canvas.transform);
        
        // Text Component hinzufügen
        timerText = textObject.AddComponent<Text>();
        
        // WICHTIG: Font setzen BEVOR Text angezeigt wird
        SetFontForText();
        
        // Position oben rechts setzen
        SetupTopRightPosition(textObject);
        
        // Text-Eigenschaften
        timerText.text = "05:00";
        timerText.fontSize = fontSize;
        timerText.color = Color.white;
        timerText.alignment = TextAnchor.MiddleRight;
        
        Debug.Log("Timer UI erstellt!");
    }

    void SetFontForText()
    {
        // Versuche verschiedene Fonts
        Font font = null;
        
        // 1. Versuch: Arial (meistens vorhanden)
        font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        
        // 2. Versuch: Legacy Font
        if (font == null)
        {
            font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        }
        
        // 3. Versuch: Irgendeinen Font laden
        if (font == null)
        {
            Font[] allFonts = Resources.FindObjectsOfTypeAll<Font>();
            if (allFonts.Length > 0)
            {
                font = allFonts[0];
            }
        }
        
        // Font setzen oder Fehler
        if (font != null)
        {
            timerText.font = font;
            Debug.Log("Font gefunden: " + font.name);
        }
        else
        {
            Debug.LogError("KEIN FONT GEFUNDEN! Text wird nicht angezeigt.");
            // Erstelle Debug-Text im Console
            Debug.Log("Timer würde anzeigen: 05:00 (oben rechts)");
        }
    }

    void SetupTopRightPosition(GameObject textObject)
    {
        RectTransform rect = textObject.GetComponent<RectTransform>();
        
        // Anchor: Oben Rechts
        rect.anchorMin = new Vector2(1, 1); // rechts (1), oben (1)
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(1, 1); // Pivot oben rechts
        
        // Position vom Bildschirmrand
        rect.anchoredPosition = new Vector2(-rightOffset, -topOffset);
        
        // Größe
        rect.sizeDelta = new Vector2(width, height);
    }

    Canvas GetCanvas()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        
        if (canvas == null)
        {
            Debug.Log("Erstelle Canvas...");
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            
            // CanvasScaler für Skalierung
            CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            
            // GraphicRaycaster für UI Interaktion
            canvasObj.AddComponent<GraphicRaycaster>();
        }
        
        return canvas;
    }

    IEnumerator TimerCountdown()
    {
        while (currentTime > 0 && timerRunning)
        {
            yield return null; // Auf nächsten Frame warten
            
            currentTime -= Time.deltaTime;
            
            // Jeden Frame aktualisieren für flüssige Anzeige
            UpdateDisplay();
            
            // Bei 0 anhalten
            if (currentTime <= 0)
            {
                currentTime = 0;
                UpdateDisplay();
                OnTimerComplete();
                yield break;
            }
        }
    }

    void UpdateDisplay()
    {
        if (timerText != null && timerText.font != null)
        {
            // Zeit berechnen
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            
            // Text formatieren
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
            // Farben basierend auf Zeit
            if (currentTime <= 30f)
                timerText.color = Color.red;
            else if (currentTime <= 60f)
                timerText.color = Color.yellow;
            else
                timerText.color = Color.white;
        }
        else
        {
            // Fallback: Console Output
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            Debug.Log($"TIMER: {minutes:00}:{seconds:00}");
        }
    }

    void OnTimerComplete()
    {
        Debug.Log("ZEIT ABGELAUFEN!");
        
        if (timerText != null)
        {
            timerText.text = "TIME'S UP!";
            timerText.color = Color.red;
        }
    }
    
    // Public Methods für Buttons
    public void PauseTimer()
    {
        timerRunning = false;
    }
    
    public void ResumeTimer()
    {
        timerRunning = true;
        StartCoroutine(TimerCountdown());
    }
}