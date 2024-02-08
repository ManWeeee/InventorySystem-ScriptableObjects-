using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Game Event")]
public class GameEvent : ScriptableObject
{
    [SerializeField]
    List<GameEventListener> gameEventListeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = gameEventListeners.Count - 1; i >= 0; i--)
            gameEventListeners[i].OnEventRaised();
    }

    public void AddListener(GameEventListener listener)
    {
        if (!gameEventListeners.Contains(listener))
            gameEventListeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        if (gameEventListeners.Contains(listener))
            gameEventListeners.Remove(listener);
    }
}
