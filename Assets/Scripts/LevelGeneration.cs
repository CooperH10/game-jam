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

    //temporary:
    private string levelPath = "Assets/Levels/level1.txt";

    
    void Start()
    {
        GenerateLevel();
    }

    
    void Update()
    {
        
    }

    GameObject InstantiateGameObject (GameObject toInstantiate, int x, int y)
    {
        return Instantiate(toInstantiate, new Vector3(x, -y, 0), Quaternion.identity);
    }

    void GenerateLevel()
    {
        string[] lines = File.ReadAllLines(levelPath);

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                switch (lines[y][x])
                {
                    case '#':
                        InstantiateGameObject(wallPrefab, x, y);
                        break;
                    case 'G':
                        InstantiateGameObject(goalPrefab, x, y);
                        //Code for Goal after instantiation 
                        break;
                    case '.':
                        break;

                    case 'S':
                        InstantiateGameObject(spikePrefab, x, y);
                        //Code for Spikes after instantiation 
                        break;

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
