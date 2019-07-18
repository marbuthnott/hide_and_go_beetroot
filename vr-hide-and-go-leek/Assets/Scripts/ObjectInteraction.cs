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

    public float startTime;
    private float scoreTime;

    void Start () 
    {
        startTime = Time.time;
        hitObjectText = GameObject.Find("Timer").GetComponent(typeof(Text)) as Text;
        timer = GameObject.Find("Timer").GetComponent(typeof(CountdownTimer)) as CountdownTimer;
        walk = GameObject.Find("Player").GetComponent(typeof(PlayerWalk)) as PlayerWalk;
        cameraSwitcher = GameObject.Find("floor").GetComponent(typeof(PlayerOrientation)) as PlayerOrientation;
    }

    void OnCollisionEnter()
    {
        Debug.Log("Hit Object");
        timer.enabled = false;
        hitObjectText.color = Color.green;
        hitObjectText.text = "You win!\nWait for\nleaderboard";
        walk.enabled = false;
        CalculateScoreTime();
        StartCoroutine("WinMessage");
        cameraSwitcher.ShowOverheadView();
        timer.StopCoroutine("LoseTime");
    }

     IEnumerator WinMessage() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Input");
    }

    void CalculateScoreTime() {
        scoreTime = (float)System.Math.Round((Time.time - startTime),2);

        PlayerPrefs.SetString("playerScore", scoreTime.ToString());
        PlayerPrefs.Save();

    }
}
