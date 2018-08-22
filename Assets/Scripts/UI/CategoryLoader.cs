using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CategoryLoader : MonoBehaviour {

    [SerializeField]
    GameObject UIPrefab;

    [SerializeField]
    FlashcardRuntimeSet flashcardSet;

	// Use this for initialization
	void Start () {

        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        List<string> categories = flashcardSet.Items.Select(x => x.Category).Distinct().ToList();

        categories = categories.OrderBy(x => x).ToList();

        foreach ( string s in categories)
        {
            GameObject go = Instantiate(UIPrefab);

            go.transform.SetParent(this.transform);

            ToggleMultiSetMember ui = go.GetComponent<ToggleMultiSetMember>();

            ui.label.text = s;
            ui.toggleReference.isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
