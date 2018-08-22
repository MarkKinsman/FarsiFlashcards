using UnityEngine;
using TMPro;
using EasyAlphabetArabic;

public class QuestionUIPrefabHandler : MonoBehaviour {

    [SerializeField]
    GameEventString onAnswerClicked;

    [SerializeField]
    TextMeshProUGUI mainTextComponent;
    [SerializeField]
    TextMeshProUGUI underTextComponent;

    private string mainText;
    public string MainText
    {
        get
        {
            return mainText;
        }
        set
        {
            mainTextComponent.text = value;
            mainText = value;
        }
    }

    private string underText;
    public string UnderText
    {
        get
        {
            return underText;
        }
        set
        {
            string formattedValue = EasyArabicCore.CorrectString(value, 2);
            underTextComponent.text = formattedValue;
            underText = formattedValue;
        }
    }

    public void OnAnswerClicked()
    {
        onAnswerClicked.Raise(mainText);
    }

}
