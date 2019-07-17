using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    // private List<HighscoreEntry> highscoreEntryList;
    private float playerTime;
    private List<Transform> highscoreEntryTransformList;
    public ScoreManager scoreManager;

    private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);  

        // playerTime = (float.Parse(PlayerPrefs.GetString("playerScore")));

        // Debug.Log(float.Parse(PlayerPrefs.GetString("playerScore")));

        playerTime = float.Parse(PlayerPrefs.GetString("playerScore"));

       AddHighscoreEntry((float)System.Math.Round(playerTime,2), "CMA");

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
        int count = 0;
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            if (++count == 10) break;
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

        float time = highscoreEntry.time;

        entryTransform.Find("timeText").GetComponent<Text>().text = time.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;

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

    private class PlayerScore {
        public List<PlayerScoreEntry> playerScoreEntryList;
    }

    [System.Serializable]
    private class PlayerScoreEntry {
        public float time;
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