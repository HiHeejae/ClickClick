using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] audioClips;

    public AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    public void Sound(int sound)
    {
        audioSource.clip = audioClips[sound];
        audioSource.Play();
    }


}
