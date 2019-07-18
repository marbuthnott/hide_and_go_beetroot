using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
 	
 	public int timeLeft;
 	public Text countdownText;
    
    public PlayerWalk walk;
    private int introTime;

    private bool switcher = false;
    public PlayerOrientation cameraSwitcher;

    void Start()
    {
		StartCoroutine("IntroTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0 && !switcher) {
        	StopCoroutine("LoseTime");
            countdownText.fontSize = 100;

        	countdownText.text = "Time's up! \nWait for \nleaderboard...";
            walk.enabled = false;
            StartCoroutine("LoseMessage"); 
            cameraSwitcher.ShowOverheadView();
            PlayerPrefs.SetString("playerScore", "0");
            PlayerPrefs.Save();
            switcher = true;
        } 
        
    }

    IEnumerator LoseTime() 
    {   
        int size = 100;
        while (true) {
    		yield return new WaitForSeconds(1);
            countdownText.fontSize = size;
    		timeLeft--;
            countdownText.color = Color.yellow;
            countdownText.text = ("" + timeLeft);
            if(timeLeft <= 5) 
            {
                size += 50;
                countdownText.color = Color.red;
            }
    	}    	
    }

    IEnumerator LoseMessage() 
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Leaderboard");
    }

    IEnumerator IntroTime() 
    {   
        introTime = 6;
        StartCoroutine ("LoseIntroTime");
        walk.enabled = false;
        yield return new WaitForSeconds(6);
        countdownText.fontSize = 600;
        countdownText.color = Color.green;
        countdownText.text = "GO";
        walk.enabled = true;
        StopCoroutine ("LoseIntroTime");
        StartCoroutine("LoseTime");  
    }

    IEnumerator LoseIntroTime() 
    {   
        while(introTime > -1) 
        {
        yield return new WaitForSeconds(1);
        introTime --;
        countdownText.text = ("Get ready...\n" + introTime);   
        }
    }
}
 