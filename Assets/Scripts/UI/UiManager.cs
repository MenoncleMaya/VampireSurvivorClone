using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager GetInstance() => instance;

    [SerializeField] Slider xpSlider;
    [SerializeField] TextMeshProUGUI tSeconds;
    [SerializeField] TextMeshProUGUI tMinutes;
    
    private int minute;
    private string seconde;

    private void Start()
    {
        instance = this;
    }


    public void UpdateXpSlider(float amount)
    {
        xpSlider.value = amount;
    }

    private void UpdateSeconds(int time)
    {
        if(time < 10) 
        {
            seconde = "0" + time.ToString();
        }
        else
        {
            seconde = time.ToString();
        }
        tSeconds.text = seconde;
    }
    private void UpdateMinutes(int time)
    {
        minute = time;
        tMinutes.text = minute.ToString();
    }

    public void UpdateTime(int seconde, int minute)
    {
        UpdateSeconds(seconde);
        UpdateMinutes(minute);    
    }
}
