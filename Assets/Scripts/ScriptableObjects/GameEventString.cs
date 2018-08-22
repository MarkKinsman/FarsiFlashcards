using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent/GameEvent(string)")]
public class GameEventString : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListenerString> eventListeners =
        new List<GameEventListenerString>();

    public void Raise(string param)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(param);
    }

    public void RegisterListener(GameEventListenerString listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerString listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}