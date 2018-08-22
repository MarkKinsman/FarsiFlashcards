using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog : MonoBehaviour {

    public static DebugLog instance;
    enum LogLevel {None, Light, Verbose}

    [SerializeField]
    LogLevel myLogLevel;

    //Singleton Pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Log(string param)
    {
        Debug.Log("String has been sent to Log: " + param);
    }

    public void LogLight(string param)
    {
        switch(myLogLevel)
        {
            case LogLevel.None:
                break;
            case LogLevel.Light:
                Debug.Log(param);
                break;
            case LogLevel.Verbose:
                Debug.Log(param);
                break;
        }
    }

    public void LogVerbose(string param, Object sender)
    {
        switch (myLogLevel)
        {
            case LogLevel.None:
                break;
            case LogLevel.Light:
                break;
            case LogLevel.Verbose:
                Debug.Log(sender.name + " (" + Time.time + "): " + param, sender);
                break;
        }
    }
}
