using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager GetInstance() => instance;

    [SerializeField] Slider xpSlider;

    private void Start()
    {
        instance = this;
    }


    public void UpdateXpSlider(float amount)
    {
        xpSlider.value = amount;
    }
}
