using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private static SoundPlayer instance;

    [SerializeField] AudioSource deathAudioSource;
    [SerializeField] AudioSource buttonAudioSource;

    public static SoundPlayer GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<SoundPlayer>(); // Or find an existing manager in the scene
        }
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

    public void PlayDeathSound()
    {
        deathAudioSource.Play();
    }
    public void PlayButtonSound()
    {
        buttonAudioSource.Play();   
    }
    public void SetVolume(float volume)
    {
        deathAudioSource.volume = volume;
    }
    public void PauseAudio()
    {
        buttonAudioSource.Pause();
        deathAudioSource.Pause();
    }
    public void UnPauseAudio()
    {
        //buttonAudioSource.UnPause();
        deathAudioSource.UnPause();
    }
}
