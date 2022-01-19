using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public TMP_Text countDown;
    public float timer = 4f;

    public TimerScript timerScript;
    private CountdownScript countDownScript;

    private void Start()
    {
        timerScript = GetComponent<TimerScript>();
    }

    void Update()
    {
        countDown.text = Mathf.FloorToInt(timer).ToString();
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timerScript.startTheTimer = true;
            timer = 0;
            Destroy(countDown);
        }
    }
}
