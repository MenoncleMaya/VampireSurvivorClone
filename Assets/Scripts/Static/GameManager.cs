using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;


    private static GameManager instance;
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>(); // Or find an existing manager in the scene
        }
        return instance;
    }

    private void Awake()
    {
        instance = this;
        isPaused = false;

        PlayerManager.GetInstance().PlayerIsDead += TogglePause;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        if (isPaused)
        {
            SoundPlayer.GetInstance().PauseAudio();
        }
        else
        {
            SoundPlayer.GetInstance().UnPauseAudio();
        }
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}
