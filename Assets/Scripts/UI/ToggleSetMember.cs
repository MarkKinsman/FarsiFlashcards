using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Toggle))]
public class ToggleSetMember : MonoBehaviour {

    public ToggleSet runtimeSet;
    [HideInInspector]
    public Toggle toggleReference;
    public TextMeshProUGUI label;

    private void OnEnable()
    {
        runtimeSet.Add(this);
        toggleReference = GetComponent<Toggle>();

        toggleReference.onValueChanged.AddListener(delegate { OnValueChanged(); });

        if (label == null)
        {
            label = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void OnDisable()
    {
        runtimeSet.Remove(this);
    }

    private void OnValueChanged()
    {
        if (toggleReference.isOn == true)
        {
            runtimeSet.ToggleOn(this);
        }
    }
}
