using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayTimer : MonoBehaviour
{
    public float seconds;
    public int minutes;
    public int hours;

    public static event MyDlegates.TimerUIdelegate UIEvent;


    // Update is called once per frame
    void Update()
    {
        //-----------------------
        seconds += Time.deltaTime;
        if (seconds > 60)
        {
            minutes++;
            seconds = 0;
        }
        if (minutes == 60)
        {
            hours++;
            minutes = 0;
        }
        //-----------------------
        UIEvent?.Invoke(hours, minutes, seconds);
    }
}
