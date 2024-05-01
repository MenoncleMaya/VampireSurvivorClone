using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private static SoundPlayer instance;

    [SerializeField] AudioSource deathAudioSource;

    public static SoundPlayer GetInstance() => instance;

    void Awake()
    {
        instance = this;
    }

    public void PlayDeathSound()
    {
        deathAudioSource.Play();
    }
}
