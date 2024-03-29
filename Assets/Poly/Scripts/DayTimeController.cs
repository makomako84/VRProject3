﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour {

    [SerializeField] Light sun;
    [SerializeField] Material[] daytimes;
    [SerializeField] Toggle[] dayTimeButtons;

    void Start () {
        if (OnLoadManager.instance.currentWeather >= 0)
            SetWeather(OnLoadManager.instance.currentWeather);
        else
            SetWeather(0);

        if(dayTimeButtons!=null)
        for (int i = 0; i < daytimes.Length; i++)
        {
            if (RenderSettings.skybox == daytimes[i])
                dayTimeButtons[i].isOn = true;
        }
    }

    /*void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "morning"))
        {
            SetWeather(0);
        }

        if (GUI.Button(new Rect(10, 120, 150, 100), "afternoon"))
        {
            SetWeather(1);
        }

        if (GUI.Button(new Rect(10, 230, 150, 100), "evening"))
        {
            SetWeather(2);
        }

        if (GUI.Button(new Rect(10, 340, 150, 100), "night"))
        {
            SetWeather(3);
        }
    }*/

    public void SetWeather (int weatherIndex)
    {
        switch(weatherIndex)
        {
            case 0:
                sun.intensity = 0.4f;
                break;
            case 1:
                sun.intensity = 0.65f;
                break;
            case 2:
                sun.intensity = 0.4f;
                break;
            case 3:
                sun.intensity = 0;
                break;
        }
        RenderSettings.skybox = daytimes[weatherIndex];
        OnLoadManager.instance.currentWeather = weatherIndex;
    }
}
