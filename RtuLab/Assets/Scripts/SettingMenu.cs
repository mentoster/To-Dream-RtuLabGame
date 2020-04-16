using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityStandardAssets.ImageEffects;

public class SettingMenu : MonoBehaviour
{

    public GameObject Settings;
    // Необходимо для отображения анимации ухода меню паузы
    public GameObject SettingsFone;
    public GameObject SettingsPanel;
    AudioSource _buttonSound;
    private bool GameOnPause;
    
    private  Animator m_Animator;
    private Animator s_Animator;//settingfone animator

    public Camera camera;
    void Start()
    {
        _buttonSound = GetComponent<AudioSource>();
        m_Animator = SettingsPanel.GetComponent<Animator>();
        s_Animator = SettingsFone.GetComponent<Animator>();

    }
  

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameOnPause)
                // ставим на паузу
            {
                _buttonSound.Play();
                Settings.SetActive(true);
                GameOnPause = true;
                Time.timeScale = 0;
                
            }
            else
            {
                _buttonSound.Play();
                Resume();
                GameOnPause = false;
            }
        }
    }  
    // функция для анимации возращения из меню
    public void Resume()
    {  
        _buttonSound.Play();
        m_Animator.SetTrigger("OffPanel");
        s_Animator.SetTrigger("OffFone");
        StartCoroutine(waiter());
    }
     
    IEnumerator waiter()
    { 
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.75f);
        Settings.SetActive(false);
    }
    public void RestartLevel()
    {
        Statics.level = -1;
        _buttonSound.Play();
        Time.timeScale = 1f;   
        Debug.Log("Restarted GameStart...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
    }
    public void Quiet()
    {
        _buttonSound.Play();
        Application.Quit();
        Debug.Log("Exit pressed ");
        Time.timeScale = 1f;
    }

    public void ToggleChanger(bool Effects)
    {
        camera.GetComponent<BloomOptimized>().enabled = Effects;
        camera.GetComponent<SunShafts>().enabled = Effects;
        camera.GetComponent<VignetteAndChromaticAberration>().enabled = Effects;
    }
}
