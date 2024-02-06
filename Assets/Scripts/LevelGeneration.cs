using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    //public GameObject enemyPrefab;
    public GameObject spikePrefab;
    public GameObject playerPrefab;
    public GameObject goalPrefab;

    public GameObject Arrow;
    public GameObject Pivot;

    //temporary, path to grab the level to play:
    private string levelPath = "Assets/Levels/level1.txt";

    
    void Start()
    {
        GenerateLevel();
    }

    
    void Update()
    {
        
    }

    //put in player?
    GameObject InstantiateGameObject (GameObject toInstantiate, int x, int y)
    {
        return Instantiate(toInstantiate, new Vector3(x, -y, 0), Quaternion.identity);
    }

    void GenerateLevel()
    {
        //get path of level and read
        string[] lines = File.ReadAllLines(levelPath);

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                switch (lines[y][x])
                {
                    //wall
                    case '#':
                        InstantiateGameObject(wallPrefab, x, y);
                        break;
                    //goal
                    case 'G':
                        InstantiateGameObject(goalPrefab, x, y);
                        //Code for Goal after instantiation 
                        break;
                    //blank space
                    case '.':
                        break;
                    //Spike, to die
                    case 'S':
                        InstantiateGameObject(spikePrefab, x, y);
                        //Code for Spikes after instantiation 
                        break;

                    //player
                    case 'P':
                        
                        GameObject playerInstance = InstantiateGameObject(playerPrefab, x, y);
                        //Code for Players after instantiation 
                        cameraFollowPlayer cameraFollow = Camera.main.GetComponent<cameraFollowPlayer>();
                        if (cameraFollow != null)
                        {
                            cameraFollow.player = playerInstance.transform;
                        }
                        break;
                }

            }
        }
    }
}
