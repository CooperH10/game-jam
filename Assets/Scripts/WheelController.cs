using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    Rigidbody2D rb;
    public Vector2 gravDirection;
    public float arrowSpeed = 45f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundObejct();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravDirection = transform.up;
            Debug.Log(gravDirection);
        }
    }

    public Transform objectToRotateAround;
    void RotateAroundObejct()
    {
        transform.RotateAround(transform.position, Vector3.forward, arrowSpeed * Time.deltaTime);
    }
}
