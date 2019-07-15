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

    void OnCollisionEnter()
    {
        timer.enabled = false;
        hitObjectText.text = "You win!";
        walk.enabled = false;
        StartCoroutine("WinMessage");
        cameraSwitcher.ShowOverheadView();
    }

     IEnumerator WinMessage() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Leaderboard");
    }
}
