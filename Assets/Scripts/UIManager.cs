using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;

public class UIManager : MonoBehaviour {

    Question currentQuestion;

    [SerializeField]
    BoolVariable teachFarsi;

    [SerializeField]
    GameObject UIPrefab;
    [SerializeField]
    Transform wordContainer;
    [SerializeField]
    Transform answerContainer;

    public void SetupQuestion(Question myQuestion)
    {
        DebugLog.instance.LogVerbose(this.name + ": Setting up question", this);
        currentQuestion = myQuestion;

        ClearQuestion();

        if(teachFarsi.Value)
        {
            CreateWord(myQuestion.Word.FarsiWord, myQuestion.Word.FarsiSpelling);
            for(int i = 0; i < myQuestion.Answers.Count(); i++)
            {
                CreateAnswer(myQuestion.Answers[i].EnglishWord, "", i);
            }
        }
        else
        {
            CreateWord(myQuestion.Word.EnglishWord, "");
            for (int i = 0; i < myQuestion.Answers.Count(); i++)
            {
                CreateAnswer(myQuestion.Answers[i].FarsiWord, myQuestion.Answers[i].FarsiSpelling, i);
            }
        }
    }

    private void ClearQuestion()
    {
        DebugLog.instance.LogVerbose(this.name + ": Clearing old questions", this);
        foreach (Transform t in wordContainer.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in answerContainer.transform)
        {
            Destroy(t.gameObject);
        }
    }

    private void CreateWord(string text, string undertext)
    {
        DebugLog.instance.LogVerbose(this.name + ": Creating word UI for " + text, this);
        GameObject newWord = Instantiate(UIPrefab);
        newWord.transform.SetParent(wordContainer);

        QuestionUIPrefabHandler textSetter = newWord.GetComponent<QuestionUIPrefabHandler>();

        if(textSetter != null)
        {
            textSetter.MainText = text;
            textSetter.UnderText = undertext;
        }

        Button button = newWord.GetComponent<Button>();

        if(button != null)
        {
            button.enabled = false;
        }
    }

    private void CreateAnswer(string text, string undertext, int answerNumber)
    {
        DebugLog.instance.LogVerbose(this.name + ": Creating answer UI for " + text, this);
        GameObject newWord = Instantiate(UIPrefab);
        newWord.transform.SetParent(answerContainer);

        QuestionUIPrefabHandler textSetter = newWord.GetComponent<QuestionUIPrefabHandler>();

        if (textSetter != null)
        {
            textSetter.MainText = text;
            textSetter.UnderText = undertext;
        }
    }
}
