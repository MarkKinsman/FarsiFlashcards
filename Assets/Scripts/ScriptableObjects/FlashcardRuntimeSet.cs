using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "RuntimeSet/FlashcardSet")]
public class FlashcardRuntimeSet : RuntimeSet<Flashcard> {

    List<Flashcard> filteredItems = new List<Flashcard>();
    [SerializeField]
    ToggleMultiSet difficultyFilter;
    [SerializeField]
    ToggleMultiSet categoryFilter;

    public Flashcard[] GetRandomFlashcards(int numberOfCards)
    {
        DebugLog.instance.LogVerbose(this.name + ": Getting " + numberOfCards + " flashcards", this);
        string category = filteredItems.Select(x => x.Category).Distinct().OrderBy(x => Guid.NewGuid()).First();
        DebugLog.instance.LogVerbose("Category is: " + category, this);
        return filteredItems.Where(x => x.Category == category).OrderBy(x => Guid.NewGuid()).Take(numberOfCards).ToArray();
    }

    public void UpdateFilters()
    {
        filteredItems = Items
            .Where(x => (difficultyFilter.selectedValues).Contains(x.Difficulty))
            .Where(z => categoryFilter.selectedValues.Contains(z.Category))
            .ToList();

        DebugLog.instance.LogVerbose("Filtered Items Count: " + filteredItems.Count(), this);
    }
}
