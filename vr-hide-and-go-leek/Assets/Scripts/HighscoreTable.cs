using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);   

        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry {time = 223, name = "BSB"},
            new HighscoreEntry {time = 12521, name = "HTY"},
            new HighscoreEntry {time = 45315, name = "DSD"},
            new HighscoreEntry {time = 56457, name = "BVC"},
            new HighscoreEntry {time = 3333, name = "YYN"},
            new HighscoreEntry {time = 35345, name = "GTH"},
            new HighscoreEntry {time = 12, name = "FRE"},
            new HighscoreEntry {time = 12342, name = "ASD"}
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 0.5f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0.32f, (-templateHeight * transformList.Count) - 1);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int time = highscoreEntry.time;

        entryTransform.Find("timeText").GetComponent<Text>().text = time.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private class HighscoreEntry {
        public int time;
        public string name;
    }
}