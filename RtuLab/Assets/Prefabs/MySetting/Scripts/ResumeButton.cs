using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    
    public GameObject Setting;
   // Необходимо для отображения анимации ухода меню паузы
   public GameObject SettingsFone;
    public GameObject SettingsPanel;

    private bool GameOnPause;
    
    private  Animator m_Animator;
    private Animator s_Animator;//settingfone animator
    void Start()
    {
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
                Setting.SetActive(true);
                GameOnPause = true;
                Time.timeScale = 0;
                
            }
            else
            {
                Resume();
                GameOnPause = false;
            }
        }
    }  
    // функция для анимации возращения из меню
    public void Resume()
         {  
             m_Animator.SetTrigger("OffPanel");
             s_Animator.SetTrigger("OffFone");
             StartCoroutine(waiter());
         }
     
         IEnumerator waiter()
         { 
             Time.timeScale = 1f;
             yield return new WaitForSeconds(0.75f);
             Setting.SetActive(false);
         }
}


