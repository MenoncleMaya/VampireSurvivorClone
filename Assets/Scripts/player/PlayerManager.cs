using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager GetInstance() => instance;

    [SerializeField]

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

    #region Health
    private const int StartMaxHealth = 20;
    [SerializeField] private int currentMaxHealth;
    [SerializeField] private int health;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        health = StartMaxHealth;
        currentMaxHealth = StartMaxHealth;
    }

    public void AddXp(int ammount)
    {
        currentXp += ammount;
        if(currentXp >= nextLv) { currentLv++; currentXp -= nextLv; nextLv *= 2;  }

        UiManager.GetInstance().UpdateXpSlider(currentXp / nextLv);

        //Debug.Log(currentXp / nextLv);
    }
    public void PlayerTakeDamage(int dmg)
    {
        health -= dmg + 20;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        UiManager.GetInstance().playerDeath();
    }
}
