using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] sounds;
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(int num)
    {
        sounds[num].Stop();
        sounds[num].Play();
    }
}
