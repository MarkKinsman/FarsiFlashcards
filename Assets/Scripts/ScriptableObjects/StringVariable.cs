using UnityEngine;

[CreateAssetMenu(menuName = "Variable/String")]
public class StringVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public string Value;
    private string StartingValue;

    public void SetValue(string value)
    {
        Value = value;
    }

    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }

    private void Awake()
    {
        StartingValue = Value;
    }

    private void OnDisable()
    {
        Value = StartingValue;
    }
}