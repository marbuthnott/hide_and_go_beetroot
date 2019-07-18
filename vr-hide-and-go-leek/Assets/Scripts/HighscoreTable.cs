using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private Transform entryPlayerScore;
    private float playerTime;
    private string playerName;
    private List<Transform> highscoreEntryTransformList;
    public ScoreManager scoreManager;

    private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");
        entryPlayerScore = entryContainer.Find("PlayerScore");

        entryTemplate.gameObject.SetActive(false);  

        playerTime = float.Parse(PlayerPrefs.GetString("playerScore"));
        playerName = PlayerPrefs.GetString("playerName");

        // add entry if player completed the maze
        if (playerTime != 0.0f) {
            AddHighscoreEntry(playerTime, playerName);
        }

        // hide playerscore if player did not find the treasure
        if (playerTime == 0) {
            entryPlayerScore.Find("posText").GetComponent<Text>().text = "";
            entryPlayerScore.Find("timeText").GetComponent<Text>().text = "";
            entryPlayerScore.Find("nameText").GetComponent<Text>().text = "";
            entryPlayerScore.Find("loseMessage").GetComponent<Text>().text = "Better luck next time";
        }

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort entry list by score
        for (int i=0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {  
                if (highscores.highscoreEntryList[j].time < highscores.highscoreEntryList[i].time) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;                            
                }  
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 0.5f;
        Transform entryTransform = Instantiate(entryTemplate, container);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        
        float time = highscoreEntry.time;

        if (time == playerTime) {
            entryPlayerScore.Find("posText").GetComponent<Text>().text = rankString;
            entryPlayerScore.Find("timeText").GetComponent<Text>().text = time.ToString();
            entryPlayerScore.Find("nameText").GetComponent<Text>().text = playerName;
        }

        if (transformList.Count < 10) {
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0.32f, (-templateHeight * transformList.Count) - 1);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("posText").GetComponent<Text>().text = rankString;

            entryTransform.Find("timeText").GetComponent<Text>().text = time.ToString();

            string name = highscoreEntry.name;

            entryTransform.Find("nameText").GetComponent<Text>().text = name;
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(float time, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { time = time, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save update Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry {
        public float time;
        public string name;
    }
}