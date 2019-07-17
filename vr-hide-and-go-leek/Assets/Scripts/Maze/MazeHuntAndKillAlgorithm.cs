using UnityEngine;
using System.Collections;

public class MazeHuntAndKillAlgorithm : MazeAlgorithm {

  private int currentRow = 0;

  private int currentColumn = 0;

  private bool courseComplete = false;

  public MazeHuntAndKillAlgorithm(MazeCell[,] cells) : base(cells) {
  }

  public override void CreateMaze() {
    HuntAndKill ();
  }

  private void HuntAndKill() {
    cells [currentRow,currentColumn].visited = true;

    while (! courseComplete) {
      Kill(); //Destroys walls until stoped by a deadend
      Hunt(); //Finds the next unvisted cell with an adjacent visited cell - from top to bottom. If none courseComplete is set to true.
    }
  }

  private void Kill() {
    while (RouteAvailable (currentRow, currentColumn)) {
      //random nnumber generator - between 1 - 4.
      int direction = NumberGenerator.GetNumber();

      if (direction == 1 && CellAvailable (currentRow - 1, currentColumn)) {
        //North
        DestroyWallIfExists (cells [currentRow, currentColumn].northWall);
        DestroyWallIfExists (cells [currentRow - 1, currentColumn].southWall);
        currentRow--;
      } else if (direction == 2 && CellAvailable (currentRow + 1, currentColumn)) {
        //South
        DestroyWallIfExists (cells [currentRow, currentColumn].southWall);
        DestroyWallIfExists (cells [currentRow + 1, currentColumn].northWall);
        currentRow++;
      } else if (direction == 3 && CellAvailable (currentRow, currentColumn + 1)) {
        //East
        DestroyWallIfExists (cells [currentRow, currentColumn].eastWall);
        DestroyWallIfExists (cells [currentRow, currentColumn + 1].westWall);
        currentColumn++;
      } else if (direction == 4 && CellAvailable (currentRow, currentColumn - 1)) {
        //West
        DestroyWallIfExists (cells [currentRow, currentColumn].westWall);
        DestroyWallIfExists (cells [currentRow, currentColumn - 1].eastWall);
        currentColumn--;
      }
      cells [currentRow, currentColumn].visited = true;
    }
  }

  private void Hunt() {
    courseComplete = true; //We set it to this to prove if its not below

    for (int rows = 0; rows < mazeRows; rows++) {
      for (int columns = 0; columns < mazeColumns; columns++) {
        if (!cells[rows, columns].visited && VisitedAdjacentCell(rows, columns)) {
          courseComplete = false; // we found another entry point - not complete, redo kill
          currentRow = rows;
          currentColumn = columns;
          DestroyAdjacentWall (currentRow, currentColumn);
          cells[currentRow, currentColumn].visited = true;
          return;
        }
      }
    }
  }

  private bool RouteAvailable(int row, int column) {
    int availableRoutes = 0;

    if (row > 0 && !cells[row - 1, column].visited) {
      availableRoutes++;
    }

    if (row < mazeRows - 1 && !cells[row + 1, column].visited) {
      availableRoutes++;
    }

    if (column > 0 && !cells[row, column - 1].visited) {
      availableRoutes++;
    }

    if (column < mazeColumns - 1 && !cells[row, column + 1].visited) {
      availableRoutes++;
    }
    return availableRoutes > 0;
  }

  private bool CellAvailable(int row, int column) {
    if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !cells[row, column].visited) {
      return true;
    } else {
      return false;
    }
  }

  private void DestroyWallIfExists(GameObject Walls) {
    if (Walls != null) {
      GameObject.Destroy (Walls);
    }
  }
  
  private bool VisitedAdjacentCell(int row, int column) {
  int visitedCells = 0;

    // Look 1 row up (north) if we're on row 1 or greater
    if (row > 0 && cells[row - 1, column].visited) {
      visitedCells++;
    }

    // Look one row down (south) if we're the second-to-last row (or less)
    if (row < (mazeRows - 2) && cells[row + 1, column].visited) {
      visitedCells++;
    }

    // Look one row left (west) if we're column 1 or greater
    if (column > 0 && cells[row, column - 1].visited) {
      visitedCells++;
    }

    // Look one row right (east) if we're the second-to-last column (or less)
    if (column < (mazeColumns-2) && cells[row, column + 1].visited) {
      visitedCells++;
    }

    // return true if there are any adjacent visited cells to this one
    return visitedCells > 0;
  }

	private void DestroyAdjacentWall(int row, int column) {
  bool wallDestroyed = false;

		while (!wallDestroyed) {
			// int direction = Random.Range (1, 5);
			int direction = NumberGenerator.GetNumber ();

			if (direction == 1 && row > 0 && cells[row - 1, column].visited) {
				DestroyWallIfExists (cells[row, column].northWall);
				DestroyWallIfExists (cells[row - 1, column].southWall);
				wallDestroyed = true;
			} else if (direction == 2 && row < (mazeRows - 2) && cells[row + 1, column].visited) {
				DestroyWallIfExists (cells [row, column].southWall);
				DestroyWallIfExists (cells [row + 1, column].northWall);
				wallDestroyed = true;
			} else if (direction == 3 && column > 0 && cells[row, column-1].visited) {
				DestroyWallIfExists (cells [row, column].westWall);
				DestroyWallIfExists (cells [row, column-1].eastWall);
				wallDestroyed = true;
			} else if (direction == 4 && column < (mazeColumns-2) && cells[row, column+1].visited) {
				DestroyWallIfExists (cells [row, column].eastWall);
				DestroyWallIfExists (cells [row, column+1].westWall);
				wallDestroyed = true;
			}
		}
	}
}