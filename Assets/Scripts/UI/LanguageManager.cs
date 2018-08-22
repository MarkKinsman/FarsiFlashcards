using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {

    [SerializeField]
    BoolVariable teachFarsi;
    [SerializeField]
    Toggle farsiToggle;
    [SerializeField]
    Toggle englishToggle;

	// Use this for initialization
	void Awake () {
		if(teachFarsi.Value)
        {
            farsiToggle.isOn = true;
            englishToggle.isOn = false;
        }
        else
        {
            farsiToggle.isOn = false;
            englishToggle.isOn = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
