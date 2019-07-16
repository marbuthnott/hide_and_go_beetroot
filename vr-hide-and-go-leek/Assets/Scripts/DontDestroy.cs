using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    
    public float playerScore;


    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateScore(float score) {
        playerScore = score;
    }
}
