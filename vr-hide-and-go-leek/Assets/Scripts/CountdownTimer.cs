using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
 	
 	public int timeLeft = 60;
 	public Text countdownText;

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
        }
    }

    IEnumerator LoseTime() {
    	while (true) {
    		yield return new WaitForSeconds(1);
    		timeLeft--;
    	}    	
    }
}
 