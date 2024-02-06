using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //public static int index = 0;
    //public LevelGeneration levelGen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //levelGen.index++;
        //index++;
        //levelGen.GenerateLevel(index);
    }
}
