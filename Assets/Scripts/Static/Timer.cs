using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float seconds;
    private int minutes;

    private void Awake()
    {
        seconds = 0f;
        minutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            seconds -= 60;
            ++minutes;
            UiManager.GetInstance().UpdateMinute(minutes);
            EnemySpawner.GetInstance().WaveStarter();
        }
        if(seconds.ConvertTo<int>() == 60)
        {
        UiManager.GetInstance().UpdateSecond(59);
        }
        else
        {
        UiManager.GetInstance().UpdateSecond(seconds.ConvertTo<int>());
        }
    }
}
