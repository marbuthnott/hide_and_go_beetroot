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

    void OnCollisionEnter()
    {
        Debug.Log("Hit Object");
        timer.enabled = false;
        hitObjectText.text = "You win!";
        walk.enabled = false;
        StartCoroutine("WinMessage");
    }

     IEnumerator WinMessage() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Leaderboard");
    }
}
