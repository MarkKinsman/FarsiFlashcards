[System.Serializable]
public class Question
{
    private Flashcard word;
    public Flashcard Word
    {
        get
        {
            return word;
        }
    }

    private Flashcard[] answers;
    public Flashcard[] Answers
    {
        get
        {
            return answers;
        }
    }
    
    public Question(Flashcard myWord, Flashcard[] myAnswers)
    {
        word = myWord;
        answers = myAnswers;
    }
}
