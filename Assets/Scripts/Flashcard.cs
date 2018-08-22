using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Flashcard : ScriptableObject {

    [SerializeField]
    string myId;
    public string Id
    {
        get
        {
            return myId;
        }
    }

    [SerializeField]
    string myFarsiWord;
    public string FarsiWord
    {
        get
        {
            return myFarsiWord;
        }
    }

    [SerializeField]
    string myFarsiSpelling;
    public string FarsiSpelling
    {
        get
        {
            return myFarsiSpelling;
        }
    }

    [SerializeField]
    string myEnglishWord;
    public string EnglishWord
    {
        get
        {
            return myEnglishWord;
        }
    }

    [SerializeField]
    string myCategory;
    public string Category
    {
        get
        {
            return myCategory;
        }
    }

    [SerializeField]
    string myDifficulty;
    public string Difficulty
    {
        get
        {
            return myDifficulty;
        }
    }

    [HideInInspector]
    public int correctCount = 0;
    [HideInInspector]
    public int incorrectCount = 0;
    [HideInInspector]
    public bool lastResult = false;

    public void Init(string id, string farsiWord, string farsiSpelling, string englishWord, string category, string difficulty)
    {
        myId = id;
        myFarsiWord = farsiWord;
        myFarsiSpelling = farsiSpelling;
        myEnglishWord = englishWord;
        myCategory = category;
        myDifficulty = difficulty;
    }
}
