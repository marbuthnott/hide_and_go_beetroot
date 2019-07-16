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

    public PlayerOrientation cameraSwitcher;

    void Start()
    {
		StartCoroutine("LoseTime");    
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("" + timeLeft);

        if (timeLeft <= 5) {
            countdownText.color = Color.red;
        }

        if (timeLeft <= 0) {
        	StopCoroutine("LoseTime");
        	countdownText.text = "Time's up!";
            walk.enabled = false;
            StartCoroutine("LoseMessage"); 
            cameraSwitcher.ShowOverheadView();
        } 
    }

    IEnumerator LoseTime() {
    	while (true) {
    		yield return new WaitForSeconds(1);
    		timeLeft--;
    	}    	
    }

    IEnumerator LoseMessage() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("EndMenu");
    }
}
 