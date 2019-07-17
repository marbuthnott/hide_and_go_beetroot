using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{

  public string Difficulty;
  private MazeGenerator maze;

  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  public void ChooseDifficulty(string difficulty)
  {
    Debug.Log("Clicked the loader");
    Difficulty = difficulty;
    Application.LoadLevel(1);
  }

  void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    Debug.Log($"Scene loaded = {scene.name}" );
    if(scene.name == "Main")
    {    
      setDifficulty();
      SceneManager.sceneLoaded -= OnSceneLoaded;
      Destroy(this.gameObject);
    }
  }

  void setDifficulty()
  {
    maze = GameObject.Find("Maze Generator").GetComponent(typeof(MazeGenerator)) as MazeGenerator;

    switch(Difficulty)
    {
      case "Easy":
        maze.gridSize = maze.EasySize;
        break;
      case "Medium":
        maze.gridSize = maze.MediumSize;
        break;
      case "Hard":
        maze.gridSize = maze.HardSize;
        break;
      default:
        maze.gridSize = maze.MediumSize;
        break;
    }
  }
}
