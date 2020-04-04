using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private float Volume =1f;

    
    // сохраняем на старте значение нашей музыки и звука как 1, чтобы избежать багов 
    private void Start()
    {
        if(!PlayerPrefs.HasKey("SetVolumeMusic"))
        {
            PlayerPrefs.SetFloat("VolumeMusic",  1); 
            PlayerPrefs.SetFloat("SoundVolume",  1);
        }
    }

  

    public void SetVolumeMusic(float vol)
    {
        Volume = vol;
        PlayerPrefs.SetFloat("VolumeMusic",  Volume); 
    }
    public void SetVolumeSound(float vol)//music
    {
        Volume = vol;
        PlayerPrefs.SetFloat("SoundVolume",  Volume);
    }
}
