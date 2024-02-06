using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    public Text timer;
    public float myTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "TEST";
    }

    // Update is called once per frame
    void Update()
    {
        myTimer += Time.deltaTime;
        timer.text = "Time: " + (int)myTimer;


    }
}
