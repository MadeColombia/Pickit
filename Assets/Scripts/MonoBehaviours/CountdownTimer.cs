using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public float TimeLeft;
    bool timerOn = false;

    [SerializeField] Text timer;
    void Start()
    {
        timerOn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

            }
            else
            {
                TimeLeft = 0;
                timerOn = false;
            }


        }
        
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
