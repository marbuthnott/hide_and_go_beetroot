using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager SM;
    
    public float playerScore;

    void Awake() {

        DontDestroyOnLoad(gameObject);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("score");
        if (objs.Length > 1)
        {
            Destroy(objs[0].gameObject);
        }
    }

    // void start() {
    //     // Scene currentScene = SceneManager.GetActiveScene();

    //     // string sceneName = currentScene.name;

    //     // if (sceneName == "StartMenu") {
    //         Destroy(gameObject);
    //     // }           
    // }
    public void UpdateScore(float score) {
        playerScore = score;
    }
}

