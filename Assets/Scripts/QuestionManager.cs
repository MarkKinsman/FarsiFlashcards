using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour {

    [SerializeField]
    FlashcardRuntimeSet allFlashcardsList;
    [SerializeField]
    GameEventString OnCorrectAnswer;
    [SerializeField]
    GameEventString OnIncorrectAnswer;

    [SerializeField]
    BoolVariable isSettingsOpen;

    Flashcard[] currentFlashcards;
    int correctAnswer;
    int answersPerQuestion = 4;

    [SerializeField]
    UIManager UIManager;

	// Use this for initialization
	void Start ()
    {
        LoadNewQuestion();
	}

    public void LoadNewQuestion()
    {

        Debug.Log("Attempting to loading New Question");

        if(isSettingsOpen.Value)
        {
            return;
        }

        Debug.Log("Loading New Question");

        DebugLog.instance.LogVerbose(this.name + ": Getting Objects", this);
        currentFlashcards = allFlashcardsList.GetRandomFlashcards(answersPerQuestion);
        DebugLog.instance.LogVerbose(this.name + ": New words are " + System.String.Join(" - ", currentFlashcards.Select(x => x.FarsiWord).ToArray()), this);

        DebugLog.instance.LogVerbose(this.name + ": Loading Questions", this);
        correctAnswer = Random.Range(0, currentFlashcards.Count());

        Question newQuestion = new Question(currentFlashcards[correctAnswer], currentFlashcards);
        UIManager.SetupQuestion(newQuestion);
    }

    public void QuestionAnswered(string param)
    {
        if(param == currentFlashcards[correctAnswer].EnglishWord || param == currentFlashcards[correctAnswer].FarsiWord)
        {
            OnCorrectAnswer.Raise(param);
        }
        else
        {
            OnIncorrectAnswer.Raise(currentFlashcards[correctAnswer].EnglishWord);
        }

        LoadNewQuestion();
    }
}
