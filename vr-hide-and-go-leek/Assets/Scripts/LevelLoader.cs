using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    private string playerName;

    void LoadLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadLevelLeaderboard()
    {
        playerName = GameObject.Find("InputText").GetComponent<Text>().text;
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Leaderboard");
    }
}
