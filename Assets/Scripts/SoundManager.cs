using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource, sfxSource;

    public AudioClip background, death, apple, croak;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void SFX(AudioClip audio)
    {
        //access audioclips by sfxSource Audiosource
        sfxSource.PlayOneShot(audio); 
    }

   
}
