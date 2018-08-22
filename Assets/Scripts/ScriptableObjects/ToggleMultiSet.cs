using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "RuntimeSet/ToggleMultiSet")]
public class ToggleMultiSet : RuntimeSet<ToggleMultiSetMember>
{
    public UnityEvent OnValueChanged;

    public List<ToggleMultiSetMember> selectedMembers
    {
        get
        {
            return Items.Where(x => x.toggleReference.isOn).ToList();
        }
    }

    public List<string> selectedValues
    {
        get
        {
            return Items.Where(x => x.toggleReference.isOn).Select(x => x.label.text).ToList();
        }
    }

    public void ToggleMember(ToggleMultiSetMember member)
    {
        OnValueChanged.Invoke();
    }

    public void SetAllTogglesOff()
    {
        foreach (ToggleMultiSetMember t in Items)
        {
            t.toggleReference.isOn = false;
        }
    }
}