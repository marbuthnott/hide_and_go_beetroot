using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
 	
 	public int timeLeft = 10;
 	public Text countdownText;
    public PlayerWalk walk;

    void Start()
    {
		StartCoroutine("LoseTime");    
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("" + timeLeft);

        if (timeLeft <= 0) {
        	StopCoroutine("LoseTime");
        	countdownText.text = "Time's up!";
            walk.enabled = false;
            StartCoroutine("LoseMessage"); 
        } 
    }

    IEnumerator LoseTime() {
    	while (true) {
    		yield return new WaitForSeconds(1);
    		timeLeft--;
    	}    	
    }

    IEnumerator LoseMessage() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Leaderboard");
    }
}
 