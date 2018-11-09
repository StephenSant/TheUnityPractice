using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerClock : MonoBehaviour
{
    public float timer;//time in float
    public string clockTime1;//time converted into string
    public string clockTime2;
    public GUIStyle text;
    public DateTime dateTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        dateTime = DateTime.Now;
        if (timer != 0)
        {
            timer += Time.deltaTime;
        }

        if (timer < 0)
        {
            timer = 0;
        }
    }
    private void OnGUI()
    {
        int mins = Mathf.FloorToInt(timer / 60);
        int secs = Mathf.FloorToInt(timer - mins * 60);
        clockTime1 = string.Format("{0:0}:{1:00}",mins,secs);
        clockTime2 = string.Format("{0:0}:{1:00}", dateTime.Hour,dateTime.Minute );
        GUI.Label(new Rect(10,25,250,100), clockTime1, text);
        GUI.Label(new Rect(10,10,100,100), clockTime2, text);
    }
}
