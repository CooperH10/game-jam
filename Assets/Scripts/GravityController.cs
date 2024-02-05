using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public GameObject Arrow;
    public float gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            float angle = Arrow.transform.localRotation.eulerAngles.z;
            Debug.Log(angle);
            Vector2 grav = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
            Physics2D.gravity = grav * gravity;

            //Vector3 coords = Quaternion.Euler(0, angle, 0) * Vector3.right * mag;
        }
        
    }
}
