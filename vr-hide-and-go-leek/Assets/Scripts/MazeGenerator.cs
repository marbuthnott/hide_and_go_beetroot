using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int gridSize;
    public GameObject tile;
    
    private List<Vector3> spaces;
    private List<Vector3> tiles;

    private GameObject previousTile;
    private GameObject currentTile;


    private List<Vector3> possibleDirections;
    private Vector3 targetLocation;

    void Start()
    {
        populateSpaces();
        gridSize = (gridSize - 1) * 5;
        RunAndSeek();
    }

    void populateSpaces()
    {
        spaces = new List<Vector3>();
        for(int x = 0; x < gridSize; x++)
        {
            for(int z = 0; z < gridSize; z++)
            {
                spaces.Add(new Vector3(x * 5,0,z * 5));
            }
        }
        foreach(Vector3 space in spaces)
        {
            Debug.Log(space);
        }
    }

    void RunAndSeek()
    {
        tiles = new List<Vector3>();
        possibleDirections = new List<Vector3>();


        currentTile = Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);
        currentTile.name = $"tile {currentTile.transform.position.x},{currentTile.transform.position.z}";

        tiles.Add(currentTile.transform.position);
        
        while(true)
        {
            buildMaze();
        }
        
        // StartCoroutine("buildMazeSlowly");

    }

    void buildMaze()
    {
        chooseNextLocation();
        removeForwardWall();
        previousTile = currentTile;
        currentTile = Instantiate(tile, new Vector3(targetLocation.x, 0, targetLocation.z), Quaternion.identity);
        currentTile.name = $"tile {currentTile.transform.position.x},{currentTile.transform.position.z}";
        removeBackwardsWall();
        tiles.Add(currentTile.transform.position);
    }

    IEnumerator buildMazeSlowly()
    {
        yield return new WaitForSeconds(0.1F);
        chooseNextLocation();
        removeForwardWall();
        previousTile = currentTile;
        currentTile = Instantiate(tile, new Vector3(targetLocation.x, 0, targetLocation.z), Quaternion.identity);
        currentTile.name = $"tile {currentTile.transform.position.x},{currentTile.transform.position.z}";
        removeBackwardsWall();
        tiles.Add(currentTile.transform.position);
        StartCoroutine("buildMazeSlow");
    }

    void chooseNextLocation()
    {
        checkWhichDirectionsAreViable();
        chooseFromPossibles();
    }

    void checkWhichDirectionsAreViable()
    {
        possibleDirections.Add(new Vector3(currentTile.transform.position.x + 5, 0, currentTile.transform.position.z));
        possibleDirections.Add(new Vector3(currentTile.transform.position.x - 5, 0, currentTile.transform.position.z));
        possibleDirections.Add(new Vector3(currentTile.transform.position.x, 0, currentTile.transform.position.z + 5));
        possibleDirections.Add(new Vector3(currentTile.transform.position.x, 0, currentTile.transform.position.z - 5));

        List<Vector3> possiblesHolder = new List<Vector3>(possibleDirections);

        foreach(Vector3 direction in possibleDirections)
        {
            foreach(Vector3 tile in tiles)
            {
                if(direction == tile)
                {
                    possiblesHolder.Remove(direction);
                }
                else if(direction.x > gridSize || direction.x < 0 || direction.z > gridSize || direction.z < 0)
                {
                    possiblesHolder.Remove(direction);
                }
            }
        }

        possibleDirections = possiblesHolder;
    }

    void chooseFromPossibles()
    {
        if(possibleDirections.Count == 0)
        {
            Debug.Log("No options!");
            Seek();
        }
        targetLocation = possibleDirections[Random.Range(0, possibleDirections.Count)];
        possibleDirections.Clear();
    }

    void removeForwardWall()
    {
        if(targetLocation.x > currentTile.transform.position.x)
        {
            deactivateWall("East");
        }
        else if(targetLocation.x < currentTile.transform.position.x)
        {
            deactivateWall("West");
        }
        else if(targetLocation.z > currentTile.transform.position.z)
        {
            deactivateWall("North");
        }
        else if(targetLocation.z < currentTile.transform.position.z)
        {
            deactivateWall("South");
        }
    }

    void removeBackwardsWall()
    {
        if(previousTile.transform.position.x > currentTile.transform.position.x)
        {
            deactivateWall("East");
        }
        else if(previousTile.transform.position.x < currentTile.transform.position.x)
        {
            deactivateWall("West");
        }
        else if(previousTile.transform.position.z > currentTile.transform.position.z)
        {
            deactivateWall("North");
        }
        else if(previousTile.transform.position.z < currentTile.transform.position.z)
        {
            deactivateWall("South");
        }
    }

    void deactivateWall(string direction)
    {
        Transform wall = currentTile.transform.Find(direction);
        wall.gameObject.SetActive(false);
    }

    void Seek()
    {
        foreach(Vector3 space in spaces)
        {
            if(tiles.Contains(space))
            {
            }
            else
            {
                RemoveConnectingWall(space);
                break;
            }
        }
    }

    void RemoveConnectingWall(Vector3 space)
    {
        List<Vector3> connectingTiles = new List<Vector3>();
        connectingTiles.Add(new Vector3(space.x + 5, 0, space.z));
        connectingTiles.Add(new Vector3(space.x - 5, 0, space.z));
        connectingTiles.Add(new Vector3(space.x, 0, space.z + 5));
        connectingTiles.Add(new Vector3(space.x, 0, space.z - 5));

        foreach(Vector3 tile in connectingTiles)
        {
            if(tiles.Contains(tile))
            {
                Debug.Log("Found a connector");
                possibleDirections.Clear();
                possibleDirections.Add(space);
                currentTile = GameObject.Find($"tile {tile.x},{tile.z}");
                Debug.Log($"{tile}, {previousTile}");
                break;
            }
        }

    }
}
