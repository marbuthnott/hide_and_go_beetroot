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
        	countdownText.text = "Time's up! Wait for leaderboard...";
            walk.enabled = false;
            StartCoroutine("LoseMessage"); 
            cameraSwitcher.ShowOverheadView();
            switcher = true;
        } 
        
    }

    IEnumerator LoseTime() 
    {   
        while (true) {
    		yield return new WaitForSeconds(1);
            countdownText.fontSize = 100;
    		timeLeft--;
            countdownText.color = Color.yellow;
            countdownText.text = ("" + timeLeft);
            if(timeLeft <= 5) 
            {
                countdownText.color = Color.red;
            }
    	}    	
    }

    IEnumerator LoseMessage() 
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("EndMenu");
    }

    IEnumerator IntroTime() 
    {   
        introTime = 6;
        StartCoroutine ("LoseIntroTime");
        walk.enabled = false;
        yield return new WaitForSeconds(6);
        countdownText.fontSize = 700;
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
 