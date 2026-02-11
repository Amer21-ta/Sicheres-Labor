using UnityEngine;

public static class GameEvents
{
    // Einfaches Event für Punkte
    public static System.Action<int> OnAddScore;
    
    // Event auslösen
    public static void AddScore(int points)
    {
        OnAddScore?.Invoke(points);
    }
}