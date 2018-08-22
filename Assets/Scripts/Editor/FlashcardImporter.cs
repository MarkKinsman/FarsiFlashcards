#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

public class FlashcardImporter : EditorWindow {

    string resourcesFolder = "Assets/Resources/Tests";
    TextAsset importFileCSV;

    Dictionary<string, Flashcard> existingCards;
    Dictionary<string, Flashcard> newCards;


    [MenuItem("Custom/Flashcard Importer")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        FlashcardImporter prefabwinow = (FlashcardImporter)EditorWindow.GetWindow(typeof(FlashcardImporter));
        prefabwinow.position = new Rect(300, 300, 400, 100);
    }

    void OnGUI()
    {
        //create an object field for the prefab/object

        GUILayout.BeginVertical();

        importFileCSV = (TextAsset)EditorGUILayout.ObjectField("CSV File", importFileCSV, typeof(TextAsset), true, GUILayout.Width(400f));
        GUILayout.Space(5);
        resourcesFolder = (String)EditorGUILayout.TextField("Save Location", resourcesFolder);

        GUILayout.EndVertical();

        GUILayout.Space(15);

        if (GUILayout.Button("Create Flashcard(s)"))
        {
            CreateFlashcards();
        }

        GUILayout.Space(15);
    }

    void CreateFlashcards()
    {
        existingCards = new Dictionary<string, Flashcard>();
        newCards = new Dictionary<string, Flashcard>();

        ReadExistingFlashcards();
        ParseCSV();
        GenerateFlashCardObjects();
    }

    void ReadExistingFlashcards()
    {
        string[] guids = AssetDatabase.FindAssets("t:Flashcard", new string[] { "/Resources/Flashcards"});
        foreach(string guid in guids)
        {
            Flashcard tempCard = (Flashcard)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(Flashcard));

            if (!existingCards.ContainsKey(tempCard.Id))
            {
                existingCards.Add(tempCard.Id, tempCard);
            }
            else
            {
                Debug.Log("ID: " + tempCard.Id + " has a duplicate scriptable object");
                continue;
            }
        }
    }

    void ParseCSV()
    {
        string sceneManagerCSVPath = AssetDatabase.GetAssetPath(importFileCSV);
        string[] allText = File.ReadAllLines(sceneManagerCSVPath);

        string splitCharString = "|";
        char splitChar = splitCharString[0];

        foreach (string s in allText)
        {
            string[] cells;

            cells = s.Split(splitChar);

            if (cells.Length == 6)
            {
                for (int i = 0; i < cells.Length; i++)
                {
                    if (cells[i] == "")
                    {
                        Debug.LogWarning("ID: " + cells[0] + " has a blank field");
                        continue;
                    }
                }

                Flashcard newCard = ScriptableObject.CreateInstance<Flashcard>();
                newCard.Init(cells[0], cells[2], cells[3], cells[1], cells[4], cells[5]);
                if (!newCards.ContainsKey(newCard.Id))
                {
                    newCards.Add(newCard.Id, newCard);
                }
                else
                {
                    Debug.Log("ID: " + newCard.Id + " is duplicated in the CSV");
                }
            }
            else
            {
                Debug.LogWarning("ID: " + cells[0] + " only has " + cells.Length + " fields");
                continue;
            }
        }
    }


    void GenerateFlashCardObjects()
    {
        foreach(KeyValuePair<string, Flashcard> kvp in newCards)
        {
            if(!existingCards.ContainsKey(kvp.Key))
            {
                Debug.Log("Creating SO for " + kvp.Value.FarsiWord);
                AssetDatabase.CreateAsset(kvp.Value, resourcesFolder + "/" + kvp.Value.Id + ".asset");
            }
            else
            {
                Debug.Log("Already have KVP for " + kvp.Value.FarsiWord);
                continue;
            }
        }
        AssetDatabase.SaveAssets();
    }
}
#endif