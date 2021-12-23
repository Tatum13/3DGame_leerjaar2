using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;

    private float timer;
    public bool startTheTimer;

    private void Update()
    {
        timer += Time.deltaTime;
        //print(FormatTimer(timer));
        
        if(startTheTimer == true)
        {
            FormatTimer(timer);
        }

    }

    private string FormatTimer(float timer)
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer - (minutes * 60);
        string milisecondes = timer.ToString().Split('.')[1].Substring(0, 3);//Aantal getallen achter de punt.
        //string milisecondes = timer.ToString().Split('.')[1];//Aantal getallen achter de punt.
        string formattedTime = minutes.ToString("D2") + ":" + seconds.ToString("D2") + "." + milisecondes;
        if (milisecondes == timer.ToString().Split('.')[1].Substring(0,3))
        {
            Debug.Log(milisecondes.Length);//Zonder de substring geeft die 5 of 6 aan. Met geeft het 3 aan.
        }
        timerText.text = "Time " + formattedTime;
        return formattedTime;
    }
   
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
