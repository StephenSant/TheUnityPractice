using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerClock : MonoBehaviour
{
    public float time;//time in float
    public string clockTime1;//time converted into string
    //public string clockTime2;
    public GUIStyle text;
    //public DateTime dateTime;
    public GameObject sun;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        //dateTime = DateTime.Now;
        time += Time.deltaTime*10;
        if (time > 360)
        {
            time = 0;
        }
        sun.transform.eulerAngles = new Vector3(time,-30,0);
    }
    private void OnGUI()
    {
        int mins = Mathf.FloorToInt(time / 60);
        int secs = Mathf.FloorToInt(time - mins * 60);
        clockTime1 = string.Format("{0:0}:{1:00}",mins,secs);
        //clockTime2 = string.Format("{0:0}:{1:00}", dateTime.Hour,dateTime.Minute );
        GUI.Label(new Rect(10,25,250,100), clockTime1, text);
        //GUI.Label(new Rect(10,10,100,100), clockTime2, text);
    }
}
