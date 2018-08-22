using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Bool")]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public bool Value;
    [SerializeField]
    bool resetOnStart = true;
    private bool StartingValue;

    public void SetValue(bool value)
    {
        Value = value;
    }

    public void SetValue(BoolVariable value)
    {
        Value = value.Value;
    }

    private void Awake()
    {
        StartingValue = Value;
    }

    private void OnDisable()
    {
        if(resetOnStart)
        {
            Value = StartingValue;
        }
    }
}