using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
//using TMPro;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<UiManager>(); // Or find an existing manager in the scene
        }
        return instance;
    }

    [Header("Main")]
    [SerializeField] Slider xpSlider;
    [SerializeField] GameObject timerHolder;
    [SerializeField] TextMeshProUGUI tSeconds;
    [SerializeField] TextMeshProUGUI tMinutes;

    #region DeathMenu
    [Header("Death")]
    [SerializeField] GameObject deathScreen;
    [SerializeField] SimpleButton mainMenuFromDeath;
    [SerializeField] SimpleButton quitGameBtn;
    #endregion

    #region PauseMenu
    [Header("Pause")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] SimpleButton resumeBtn;
    [SerializeField] SimpleButton settingsBtn;
    [SerializeField] SimpleButton mainMenuBtn;
    [SerializeField] SimpleButton quitToDesktopBtn;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeValue;
    [SerializeField] SA_Settings settings;
    [SerializeField] GameObject settingsPanel;
    #endregion

    #region LvUpMenu
    [Header("LvUp")]
    [SerializeField] GameObject LvUpMenu;
    [SerializeField] SimpleButton LvUpStat;
    [SerializeField] SimpleButton LvUpScythe;
    [SerializeField] SimpleButton LvUpAxe;

    public event Action LvUpAxeEvent;
    #endregion

    private int minute;
    private string seconde;

    private void Awake()
    {
        instance = this;

        PlayerManager.GetInstance().LevelUp += ToggleLvUpMenu;
        PlayerManager.GetInstance().PlayerIsDead += playerDeath;

        resumeBtn.OnClick += ResumeBtn;
        settingsBtn.OnClick += SettingsPanel;
        mainMenuBtn.OnClick += GoToMainMenu;
        mainMenuFromDeath.OnClick += GoToMainMenu;
        quitToDesktopBtn.OnClick += QuitGame;
        quitGameBtn.OnClick += QuitGame;

        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
        volumeSlider.maxValue = 100;
        volumeSlider.minValue = 0;
        volumeSlider.value = settings.Volume;
        SoundPlayer.GetInstance().SetVolume(settings.Volume / 100);

        LvUpStat.OnClick += LevelUpStat;
        LvUpScythe.OnClick += LevelUpScythe;
        LvUpAxe.OnClick += LevelUpAxe;
    }


    public void UpdateXpSlider(float amount)
    {
        xpSlider.value = amount;
    }

    public void UpdateSecond(int time)
    {
        if (time < 10)
        {
            seconde = "0" + time.ToString();
        }
        else
        {
            seconde = time.ToString();
        }
        tSeconds.text = seconde;
    }
    public void UpdateMinute(int time)
    {
        minute = time;
        tMinutes.text = minute.ToString();
    }

    public void playerDeath()
    {
        deathScreen.SetActive(true);
    }

    private void ResumeBtn()
    {
        SoundPlayer.GetInstance().PlayButtonSound();
        TogglePauseMenu();
    }
    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.active);
        GameManager.GetInstance().TogglePause();
    }
    private void SettingsPanel()
    {
        SoundPlayer.GetInstance().PlayButtonSound();
        settingsPanel.SetActive(!settingsPanel.active);
    }
    private void HandleVolumeChange(float value)
    {
        SoundPlayer.GetInstance().SetVolume(value / 100);
        settings.Volume = value;
        volumeValue.text = value.ToString();
    }
    private void GoToMainMenu()
    {
        SoundPlayer.GetInstance().PlayButtonSound();
        SceneManager.LoadScene(0);
    }
    private void QuitGame()
    {
        SoundPlayer.GetInstance().PlayButtonSound();
        Application.Quit();
    }

    private void LevelUpStat()
    {
        ToggleLvUpMenu();
    }
    private void LevelUpScythe()
    {
        PlayerManager.GetInstance().scytheLv++;
        if (PlayerManager.GetInstance().scytheLv == 3)
        {
            LvUpScythe.gameObject.SetActive(false);
        }
        ToggleLvUpMenu();
    }
    private void LevelUpAxe()
    {
        PlayerManager.GetInstance().axeLv++;
        if (PlayerManager.GetInstance().axeLv == 3)
        {
            LvUpAxe.gameObject.SetActive(false);
        }
        ToggleLvUpMenu();
        LvUpAxeEvent?.Invoke();
    }
    private void ToggleLvUpMenu()
    {
        GameManager.GetInstance().TogglePause();
        LvUpMenu.SetActive(!LvUpMenu.active);
    }

}
