using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerString : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventString Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEventString Response;

    protected virtual void OnEnable()
    {
        Event.RegisterListener(this);
    }

    protected virtual void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(string param)
    {
        Response.Invoke(param);
    }
}

[System.Serializable]
public class UnityEventString : UnityEvent<string> { }