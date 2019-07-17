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

    public PlayerOrientation cameraSwitcher;

    void Start()
    {
		StartCoroutine("IntroTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0) {
        	StopCoroutine("LoseTime");
        	countdownText.text = "Time's up!";
            walk.enabled = false;
            StartCoroutine("LoseMessage"); 
            cameraSwitcher.ShowOverheadView();
        } 
        StopCoroutine("InroTime");
        
    }

    IEnumerator LoseTime() 
    {   
    	while (true) {
    		yield return new WaitForSeconds(1);
    		timeLeft--;
            countdownText.color = Color.yellow;
            countdownText.text = ("" + timeLeft);
            if(timeLeft <= 5) {
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
        countdownText.fontSize = 150;
        countdownText.color = Color.green;
        countdownText.text = "GO!";
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
        countdownText.text = ("" + introTime);
        
        }
    }
}
 