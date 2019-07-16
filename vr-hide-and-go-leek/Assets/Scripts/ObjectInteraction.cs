using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
    public Text hitObjectText;
    public CountdownTimer timer;
    public PlayerWalk walk;
    public PlayerOrientation cameraSwitcher;
    public ScoreManager scoreManager;

    public float startTime;
    private float scoreTime;

    // SortedDictionary<string, float> leaderboardList;

    // void Awake() {
    //     leaderboardList = new SortedDictionary<string, float>();
    // }

    void Start() {
        startTime = Time.time;
    }

    void OnCollisionEnter() {   
        timer.enabled = false;
        hitObjectText.text = "You win!";
        walk.enabled = false;
        CalculateScoreTime();
        scoreManager.UpdateScore(scoreTime);
        StartCoroutine("WinMessage");
        cameraSwitcher.ShowOverheadView();
    }

     IEnumerator WinMessage() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Leaderboard");
    }

    void CalculateScoreTime() {
        scoreTime = Time.time - startTime;
    }

    // void AddScore() {
    //     leaderboardList.Add("Mag", scoreTime);
    //     foreach( KeyValuePair<string, float> element in leaderboardList )
    //     {
    //         Debug.Log(element.Key);
    //         Debug.Log(element.Value);
    //     }
    // }
}
