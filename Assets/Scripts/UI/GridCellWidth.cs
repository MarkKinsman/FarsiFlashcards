using System;
using UnityEngine;
using UnityEngine.UI;

public class GridCellWidth : MonoBehaviour {

    float buttonWidth;

    [SerializeField]
    GridLayoutGroup layout;
    RectTransform container;

    private void Awake()
    {
        container = layout.GetComponent<RectTransform>();   
    }

    void OnRectTransformDimensionsChange()
    {
        if((float)(Screen.width/Screen.height) >= 1)
        {
            layout.spacing = new Vector2(2, 2);
            buttonWidth = (container.sizeDelta.x - layout.spacing.x) / 2;
        }
        else
        {
            layout.spacing = new Vector2(0, 2);
            buttonWidth = (container.sizeDelta.x - layout.spacing.x);
        }

        layout.cellSize = new Vector2(buttonWidth, layout.cellSize.y);
    }
}
