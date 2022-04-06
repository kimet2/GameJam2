using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timers;
    public float timeRemaining = 30;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
                timerIsRunning = true;
                timers.text = timeRemaining.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                  timers.text = timeRemaining.ToString("f0");
                  timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
