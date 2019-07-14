using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class ObjectInteraction : MonoBehaviour
{
    public Text hitObjectText;
    public CountdownTimer timer;
    public PlayerWalk walk;

    private float startTime;
    private float scoreTime;

    // private Stopwatch stopWatch;


    void Start()
    {
        startTime = Time.time;
        // stopWatch = new Stopwatch();
        // stopWatch.Start();
    }

    void OnCollisionEnter()
    {
        UnityEngine.Debug.Log("Hit Object");
        timer.enabled = false;
        hitObjectText.text = "You win!";
        walk.enabled = false;
        UnityEngine.Debug.Log(Time.time);
        calculateScoreTime();
        StartCoroutine("WinMessage");
    }

     IEnumerator WinMessage() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EndMenu");
    }

    void calculateScoreTime()
    {
        scoreTime = Time.time - startTime;
        // scoreTime = scoreTime.ToString("F2");
        // UnityEngine.Debug.Log(scoreTime.GetType());
        // stopWatch.Stop();
        // UnityEngine.Debug.Log(stopWatch.Elapsed);
    }


}
