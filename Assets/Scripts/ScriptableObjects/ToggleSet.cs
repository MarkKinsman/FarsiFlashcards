using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "RuntimeSet/ToggleSet")]
public class ToggleSet : RuntimeSet<ToggleSetMember>
{
    public UnityEvent OnValueChanged;

    public ToggleSetMember selectedMember
    {
        get
        {
            return Items.FirstOrDefault(x => x.toggleReference.isOn == true);
        }
    }    

    public void ToggleOn(ToggleSetMember member)
    {
        List<ToggleSetMember> trueToggles = Items.Where(x => x.toggleReference.isOn == true).ToList();

        foreach(ToggleSetMember t in trueToggles)
        {
            if (t != member)
            {
                t.toggleReference.isOn = false;
            }
        }
        OnValueChanged.Invoke();
    }

    public void SetAllTogglesOff()
    {
        foreach(ToggleSetMember t in Items)
        {
            t.toggleReference.isOn = false;
        }
    }
}
