using UnityEngine;
using UnityEngine.UI;

public class Bag_Musik : MonoBehaviour
{
    [SerializeField] Slider bg_Musik;
   
    
    void Start()
    {
        // Überprüfen, ob eine Lautstärkeeinstellung gespeichert wurde
        if (!PlayerPrefs.HasKey("MusikVolume")) // Korrektur: HaKey → HasKey
        {
            // Wenn nicht, Standardwert 1 setzen und speichern
            PlayerPrefs.SetFloat("MusikVolume", 1f); // Korrektur: Semikolon hinzugefügt
            PlayerPrefs.Save(); // Explizites Speichern empfohlen
        }
        
        // Lautstärkeeinstellungen laden
        LautstaerkeLaden();
        
        // Listener für Slider-Änderungen hinzufügen
        if (bg_Musik != null)
        {
            bg_Musik.onValueChanged.AddListener(BeiSliderAenderung);
        }
    }
    
    void BeiSliderAenderung(float wert)
    {
        // Direkt den Slider-Wert verwenden
        AudioListener.volume = wert;
        LautstaerkeSpeichern();
    }
    
    // Alternative Methode für direkten Aufruf (kann an Slider-Event gebunden werden)
    public void LautstaerkeAendern() // Korrektur: Valume → Volume
    {
        if (bg_Musik != null)
        {
            AudioListener.volume = bg_Musik.value;
            LautstaerkeSpeichern();
        }
    }
    
    private void LautstaerkeLaden()
    {
        if (bg_Musik != null)
        {
            float gespeicherteLautstaerke = PlayerPrefs.GetFloat("MusikVolume", 1f); // Standardwert verwenden
            bg_Musik.value = gespeicherteLautstaerke;
            AudioListener.volume = gespeicherteLautstaerke; // AudioListener ebenfalls aktualisieren
        }
    }
    
    private void LautstaerkeSpeichern()
    {
        if (bg_Musik != null)
        {
            PlayerPrefs.SetFloat("MusikVolume", bg_Musik.value);
            PlayerPrefs.Save(); // Explizit speichern für dauerhafte Speicherung
        }
    }
    
    // Optional: Beim Beenden speichern
    void OnApplicationQuit()
    {
        LautstaerkeSpeichern();
    }
}