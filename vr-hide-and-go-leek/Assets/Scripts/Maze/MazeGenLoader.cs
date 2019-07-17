using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeGenLoader : MonoBehaviour {

  public int mazeRows, mazeColumns;

  public GameObject Walls;
  public GameObject Floor;
  public GameObject Goal;

  public float size = 2f;

  private MazeCell[,] cells;

  // Use this for initialization
  void Start () {
    InitializeMaze ();

    MazeAlgorithm mazeAlgo = new MazeHuntAndKillAlgorithm(cells);
 		mazeAlgo.CreateMaze();

  }

  // Update is called once per frame
  void Update () {

  }

  private void InitializeMaze() {
    cells = new MazeCell[mazeRows,mazeColumns];

    for (int rows = 0; rows < mazeRows; rows++) {
      for(int columns = 0; columns < mazeColumns; columns++) {
        cells [rows, columns] = new MazeCell ();

        //floor
        cells [rows, columns] .floor = Instantiate (Floor, new Vector3 (rows*size, -(size/2f), columns*size), Quaternion.identity) as GameObject;
        cells [rows, columns] .floor.name = "Floor " + rows + "," + columns;
				cells [rows, columns] .floor.transform.Rotate (Vector3.right, 90f);

        //Columns
        //West
        if (columns == 0) {
          cells[rows,columns].westWall = Instantiate (Walls, new Vector3 (rows*size, 0, (columns*size) - (size/2f)), Quaternion.identity) as GameObject;
          cells[rows,columns].westWall.name = "West Wall" + rows + "," + columns;
        }
        //East
        cells[rows,columns].eastWall = Instantiate (Walls, new Vector3 (rows*size, 0, (columns*size) + (size/2f)), Quaternion.identity) as GameObject;
        cells[rows,columns].eastWall.name = "East Wall" + rows + "," + columns;

        //Rows
        //North
        if (rows == 0) {
          cells [rows, columns] .northWall = Instantiate (Walls, new Vector3 ((rows*size) - (size/2f), 0,  columns*size), Quaternion.identity) as GameObject;
          cells [rows, columns] .northWall.name = "North Wall" + rows + "," + columns;
				  cells [rows, columns] .northWall.transform.Rotate (Vector3.up * 90f);
        }
        //South
        cells [rows, columns] .southWall = Instantiate (Walls, new Vector3 ((rows*size) + (size/2f), 0,  columns*size), Quaternion.identity) as GameObject;
        cells [rows, columns] .southWall.name = "South Wall" + rows + "," + columns;
				cells [rows, columns] .southWall.transform.Rotate (Vector3.up * 90f);
      }
    }
  }
}