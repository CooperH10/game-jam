using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    //private GameObject Arrow = GameObject.FindGameObjectWithTag("Arrow");
    public GameObject Arrow;
    public float gravity = 9.8f;
    public Vector2 gravDir = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            float angle = Arrow.transform.localRotation.eulerAngles.z + 90;
            Debug.Log(angle);
            gravDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
            Debug.Log(gravDir);
        }
        
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = gravDir * gravity;
    }
}
