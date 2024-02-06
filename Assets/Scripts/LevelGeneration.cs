using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public static LevelGeneration Instance;
    //public int index = 0;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    //public GameObject enemyPrefab;
    public GameObject spikePrefab;
    public GameObject playerPrefab;
    public GameObject goalPrefab;

    //public GameObject Arrow;
    //public GameObject Pivot;


    //temporary, path to grab the level to play:
    //private string levelPath = "Assets/Levels/level1.txt";
    private void Awake()
    {
        Instance = this;
    }
    public List<string> paths = new List<string>();


    void Start()
    {
        paths.Add("Assets/Levels/starter_level.txt");
        paths.Add("Assets/Levels/spike-level.txt");
        paths.Add("Assets/Levels/level1.txt");
        paths.Add("Assets/Levels/level3.txt");
        GenerateLevel(GravityController.index);
    }

    
    void Update()
    {
        
    }

    //put in player?
    static GameObject InstantiateGameObject (GameObject toInstantiate, int x, int y)
    {
        return Instantiate(toInstantiate, new Vector3(x, -y, 0), Quaternion.identity);
    }

    public void GenerateLevel(int index)
    {
        //get path of level and read
        string[] lines = File.ReadAllLines(paths[index]);

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
