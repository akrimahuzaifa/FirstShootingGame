using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public StartGame userNameToTransfer;
    GameObject objToFind;

    Text bulletStatsTextBox;
    Text timerTextBox;
    Text userNameToShow;
    Text countDownTextBox;

    //=========FramRateWork=============================
/*    public Text fpsText;
    public float deltaTime;*/
    //=========FramRateWork=============================

    private void OnEnable()
    {
        Gun.UIEvent += BulletsLeft;
        GamePlayTimer.UIEvent += HoursMinutesSecondsLeft;
        Countdown.UIEventForCountDown += CountDownTimer;       
    }

    private void OnDisable()
    {
        Gun.UIEvent -= BulletsLeft;
        GamePlayTimer.UIEvent -= HoursMinutesSecondsLeft;
        Countdown.UIEventForCountDown -= CountDownTimer;
    }

    void Start()
    {  
        TextBoxObjects();
        ShowPlayerName();
    }

    private void Update()
    {
        //=========FramRateWork=============================
        /*deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();*/
        //=========FramRateWork=============================
    }

    void TextBoxObjects()
    {
        userNameToTransfer = FindObjectOfType<StartGame>();
        bulletStatsTextBox = GameObject.Find("MagzineText").GetComponent<Text>();
        timerTextBox = GameObject.Find("GamePlayTimeText").GetComponent<Text>();
        userNameToShow = GameObject.Find("PlayerNameShowText").GetComponent<Text>();
        countDownTextBox = GameObject.Find("CountDownText").GetComponent<Text>();

        //=========FramRateWork=============================
        /*        fpsText = GameObject.Find("FramRateText").GetComponent<Text>();
                fpsText.text = "FrameRate: " + fpsText.text;*/
        //=========FramRateWork=============================
    }

    void ShowPlayerName()
    {
        if (userNameToTransfer == null)
        {
            userNameToShow.text = "Default User";
        }
        else
        {
            userNameToShow.text = userNameToTransfer.userName;
            foreach (GameObject g in SceneManager.GetSceneByName("StartGameScene1").GetRootGameObjects())
            {
                g.SetActive(false);
                //Debug.Log(g);
            }
        }
        //============ForFileSystem=============================
        /*userNameToShow.text = File.ReadAllText("Akrima.txt");*/
        //============ForFileSystem=============================
    }

    void BulletsLeft(int magzine)
    {
        
        bulletStatsTextBox.text = "Bullets left: " + magzine;
        //Debug.Log("BulletsLeftTxxt: " + bulletStatsTextBox.text);
    }

    void HoursMinutesSecondsLeft(int hours, int minutes, float seconds)
    {
        timerTextBox.text = hours + " : " + minutes + " : " + seconds.ToString("F2");
    }

    void CountDownTimer(int timeToStartFrom)
    {
        //countDownTextBox.text = timeToStartFrom.ToString();
        int time = (int)Mathf.Round(timeToStartFrom);
        countDownTextBox.text = time.ToString();

        if (time > 40)
        {
            countDownTextBox.color = Color.green;
        }
        else if (time > 20)
        {
            countDownTextBox.color = Color.yellow;
        }
        else if (time > 0)
        {
            countDownTextBox.color = Color.red;
        }
    }
}
