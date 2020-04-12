using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    public GameObject startCamera;
    public GameObject player;
    public GameObject startPlayer;
    public GameObject startMenu;
    public TMP_Text buildVersion;
    public GameObject settings;
    AudioSource _buttonSound;
    void Start()
    {
        _buttonSound = GetComponent<AudioSource>();
        if (Statics.level == -1)
        {
            buildVersion.text = "build " + Application.version.ToString();
        }
        else
        {
           startGame();
        }

    }

    public void startGame()
    {
        _buttonSound.Play();
        Destroy(startMenu);
        Destroy(startCamera);
        Destroy(startPlayer);
        player.SetActive(true);
      
    }

    public void callSettingMenu()
    {
        settings.SetActive(true);
        _buttonSound.Play();
    }
}
