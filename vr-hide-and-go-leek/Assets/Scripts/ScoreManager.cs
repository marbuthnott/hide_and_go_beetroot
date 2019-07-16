using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    
    public float playerScore;
    // List<KeyValuePair<string, float>> leaderboard;
    // private List<HighscoreEntry> highscoreEntryList;

    void Awake() {
        // leaderboard = new List<KeyValuePair<string, float>>();
        // highscoreEntryList = new List<HighscoreEntry>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateScore(float score) {
        playerScore = score;
        // AddScoreToList();
    }

    // void AddScoreToList() {
    //     leaderboard.Add(new KeyValuePair<string, float>("JIM", playerScore));
    //     foreach (var score in leaderboard) {
    //         Debug.Log(score.Key);
    //         Debug.Log(score.Value);
    //     }
    // }

    // void ScoreToJSONFile() {

    // }
}
