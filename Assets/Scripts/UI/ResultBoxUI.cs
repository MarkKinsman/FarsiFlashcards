using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultBoxUI : MonoBehaviour {
    [SerializeField]
    Color correctColor;
    [SerializeField]
    Color incorrectColor;

    [SerializeField]
    Image backgroundImage;
    [SerializeField]
    TextMeshProUGUI resultText;

    public void OnAnsweredCorrectly(string answer)
    {
        backgroundImage.color = correctColor;
        resultText.text = "Correct!";
    }

    public void OnAnsweredIncorrectly(string answer)
    {
        backgroundImage.color = incorrectColor;
        resultText.text = "Incorrect\n<size=80>Correct: " + answer;
    }
}
