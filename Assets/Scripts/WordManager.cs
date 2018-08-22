using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;
    [SerializeField]
    FlashcardRuntimeSet cardsSet;

    //Singleton Pattern
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        Resources.LoadAll("Flashcards");

        Flashcard[] cardList = Resources.FindObjectsOfTypeAll(typeof(Flashcard)) as Flashcard[];

        DebugLog.instance.LogVerbose("Found " + cardList.Count() + " Flashcards in resources", this);

        foreach (Flashcard f in cardList)
        {
            cardsSet.Add(f);
        }
    }

    public void UpdateFilters()
    {
        cardsSet.UpdateFilters();
    }
}
