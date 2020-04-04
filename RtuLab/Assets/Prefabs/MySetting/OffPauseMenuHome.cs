using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPauseMenuHome : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject pauseMenuUi;
    public GameObject SettingsFone;
    public GameObject SettingsPanel;
    
    
   private  Animator m_Animator;
    private Animator s_Animator;//settingfone animator
    void Start()
    {
        m_Animator = SettingsPanel.GetComponent<Animator>();
        s_Animator = SettingsFone.GetComponent<Animator>();

    }
    public void OnButtonClick()
    {  
        m_Animator.SetTrigger("OffPanel");
        s_Animator.SetTrigger("OffFone");
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    { Panel1.SetActive(true);
        Panel2.SetActive(true);
        Panel3.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        OffPanel();
    }

    private void OffPanel()
    {
        
        pauseMenuUi.SetActive(false);
       
    }
}
