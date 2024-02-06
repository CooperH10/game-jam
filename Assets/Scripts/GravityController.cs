using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityController : MonoBehaviour
{

    //private GameObject Arrow = GameObject.FindGameObjectWithTag("Arrow");
    public GameObject Arrow;
    public float gravity = 9.8f;
    public Vector2 gravDir = new Vector2(0,0);

    public static int index = 0;
    //public LevelGeneration levelGen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when you hit space you change the gravity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //get the direction of the arrow
            float angle = Arrow.transform.localRotation.eulerAngles.z + 90;
            //Debug.Log(angle);
            //change the gravity direction
            gravDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
            //Debug.Log(gravDir);
        }
        
    }


    private void FixedUpdate()
    {
        //gravity update
        Physics2D.gravity = gravDir * gravity;
    }

    //player death
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.CompareTag("Goal"))
        {
            index++;
            LevelGeneration.Instance.GenerateLevel(index);
        }
    }
}
