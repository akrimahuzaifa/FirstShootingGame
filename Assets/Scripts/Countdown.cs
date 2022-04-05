using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float timeToStartFrom = 60;

    public static event MyDlegates.UIDelegate UIEventForCountDown;

    // Update is called once per frame
    void Update()
    {
        timeToStartFrom -= Time.deltaTime;
        UIEventForCountDown?.Invoke((int)timeToStartFrom);

        if(timeToStartFrom <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
