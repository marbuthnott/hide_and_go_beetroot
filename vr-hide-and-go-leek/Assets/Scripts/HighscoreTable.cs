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
    	entryContainer = transform.Find("highscoreEntryContainer");
    	entryTemplate = entryContainer.Find("highscoreEntryTemplate");

    	entryTemplate.gameObject.SetActive(false);

        // highscoreEntryList = new List<HighscoreEntry>() {
        //     new HighscoreEntry {score = 223, name = "BSB"},
        //     new HighscoreEntry {score = 12521, name = "HTY"},
        //     new HighscoreEntry {score = 45315, name = "DSD"},
        //     new HighscoreEntry {score = 56457, name = "BVC"},
        //     new HighscoreEntry {score = 3333, name = "YYN"},
        //     new HighscoreEntry {score = 35345, name = "GTH"},
        //     new HighscoreEntry {score = 12, name = "FRE"},
        //     new HighscoreEntry {score = 12342, name = "ASD"}
        // };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i=0; i < highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscoreEntryList.Count; j++) {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score) {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        // Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        // string json = JsonUtility.ToJson(highscores);
        // PlayerPrefs.SetString("highScoreTable", json);
        // PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highScoreTable"));
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch(rank) {
        default:
            rankString = rank + "TH"; break;
        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        Debug.Log(entryTransform.Find("positionText"));
        entryTransform.Find("positionText").GetComponent<Text>().text = rankString;


        int score = highscoreEntry.score;
        Debug.Log(entryTransform.Find("time"));
        entryTransform.Find("time").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        Debug.Log(entryTransform.Find("playerName"));
        entryTransform.Find("playerName").GetComponent<Text>().text = name;
        
        transformList.Add(entryTransform);
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}
