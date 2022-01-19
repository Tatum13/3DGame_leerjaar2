using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;

    private float timer;
    public bool startTheTimer;

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

 
    private void Update()
    {
        if(startTheTimer == true)
        {
            timer += Time.deltaTime;
            timerText.text = "Time " + FormatTime(timer);
        }
    }

    /*
    private string FormatTimer(float timer)
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer - (minutes * 60);
        string miliseconds = timer.ToString().Split('.')[1].Substring(0, 3);//Aantal getallen achter de punt.En gekke error.
        //string milisecondes = timer.ToString().Split('.')[1];//Aantal getallen achter de punt.
        string formattedTime = minutes.ToString("D2") + ":" + seconds.ToString("D2") + "." + miliseconds;
        if (miliseconds == timer.ToString().Split('.')[1].Substring(0,3))
        {
            //Debug.Log(milisecondes.Length);//Zonder de substring geeft die 5 of 6 aan. Met geeft het 3 aan.
        }
        timerText.text = "Time " + formattedTime;
        return formattedTime;
    }
   */
    /*
    private float timer;
    public float delay = 0f;
    public bool startTheTimer;

    public float startTimer;
    public double testTime;


    private void Start()
    {
        startTimer = Time.time;
        string s = "Hoezo begrijp, ik dit niet?";

        string[] subs = s.Split(' ', ',');

        foreach (var sub in subs)
        {
            Debug.Log(sub);
        }
    }
    private void Update()
    {
        if(startTheTimer == true)
        {
            StartTimer();
        }
    }
    void StartTimer()
    {
        float time = Time.time - startTimer;
        string nul = "0";
        string nul2 = "0";
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString();

        string[] sec = seconds.Split(' ', ' ', ' ');

        foreach(string s in sec)
        {
            timerText.text = "Time " + minutes + nul + ":" + s;
            if(time >= 10)
            {
                timerText.text = "Time " + minutes + nul + ":" + s;
            }
            else
            {
                timerText.text = "Time " + minutes + nul + ":" + nul2 + s;
            }
        }
    }
    */
}
