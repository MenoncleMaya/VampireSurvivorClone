using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager GetInstance()
    {

        if (instance == null)
        {
            instance = FindObjectOfType<PlayerManager>(); // Or find an existing manager in the scene
        }
        return instance;

    }

    public event Action PlayerIsDead;
    public event Action LevelUp;


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
    public int scytheLv;
    public int axeLv;

    #region Health
    private const int StartMaxHealth = 20;
    [SerializeField] private int currentMaxHealth;
    [SerializeField] private int health;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        health = StartMaxHealth;
        currentMaxHealth = StartMaxHealth;
    }

    public void AddXp(int ammount)
    {
        currentXp += ammount;
        if (currentXp >= nextLv) { PlayerLevelUp(); currentXp -= nextLv; nextLv *= 2; }

        UiManager.GetInstance().UpdateXpSlider(currentXp / nextLv);

        //Debug.Log(currentXp / nextLv);
    }
    public void PlayerTakeDamage(int dmg)
    {
        health -= dmg + 20;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerIsDead?.Invoke();
    }
    private void PlayerLevelUp()
    {
        currentLv++;
        LevelUp?.Invoke();
    }
}
