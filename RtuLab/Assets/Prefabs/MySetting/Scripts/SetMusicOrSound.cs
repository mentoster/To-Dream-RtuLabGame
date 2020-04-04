using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicOrSound : MonoBehaviour
{
    // скрипт вешается на звук или музыку
    // в зависимости  от этого ставится флажок
    private AudioSource _audioSource;
    public bool ItIsMusic=true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (ItIsMusic)
        {
            _audioSource.volume= PlayerPrefs.GetFloat("VolumeMusic"); 
        }
        else
        {
            _audioSource.volume= PlayerPrefs.GetFloat("SoundVolume"); 
        }
    }
}
