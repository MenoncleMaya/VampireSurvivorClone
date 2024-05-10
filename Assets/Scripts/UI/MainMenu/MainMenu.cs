using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MainMenuUi : MonoBehaviour
{
    #region mainButton
    [SerializeField] SimpleButton bPlay;
    [SerializeField] SimpleButton bSettings;
    [SerializeField] SimpleButton bQuit;
    #endregion

    [SerializeField] SA_Settings settings;

    #region menus
    [SerializeField] GameObject Main;
    [SerializeField] GameObject Settings;
    #endregion

    #region Settings
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volume;
    [SerializeField] SimpleButton bSettingsBack;
    //[SerializeField] SimpleSlider volumeSliderScript;
    #endregion

    private void Awake()
    {
        bPlay.OnClick += GoToGameScene;
        bSettings.OnClick += OpenSettings;
        bQuit.OnClick += Quit;
        bSettingsBack.OnClick += BackToMain;
        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);

        volumeSlider.maxValue = 100;
        volumeSlider.minValue = 0;
        volumeSlider.value = settings.Volume;
        volume.text = settings.Volume.ToString();
    }


    private void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenSettings()
    {
        Main.SetActive(false);
        Settings.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void BackToMain()
    {
        Settings.SetActive(false);
        Main.SetActive(true);
    }

    private void HandleVolumeChange(float value)
    {
        settings.Volume = value.ConvertTo<int>();
        volume.text = value.ToString();
    }
}
