using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager GetInstance() => instance;

    public float dammageModifier;
    public float healtModifier;
    public float speedModifier;
    public float flatDammageModifier;
    public float flatHealtModifier;
    public float flatSpeedModifier;
    public float currentXp;
    public float nextLv;
    public int currentLv;
    public const int LV_MAX = 10;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    public void AddXp(int ammount)
    {
        currentXp += ammount;
        if(currentXp >= nextLv) { currentLv++; currentXp -= nextLv; nextLv *= 2;  }

        UiManager.GetInstance().UpdateXpSlider(currentXp / nextLv);

        //Debug.Log(currentXp / nextLv);
    }
}
