using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    //кто говорит 
    public string WhoSaid;
    //Добавляем субтитры
    public string TextOfVoice;
    //Где будут Воспроизводится субтитры
    private  GameObject SubObj;

    private TMP_Text Sub;
    //время для субтитров
    public float time;

    public bool UseAudioSource=true;

    //Использовании m_ToggleChange гарантирует, что звук не воспроизводится несколько раз
    bool CanPlay=true;
    void Start()
    {
        //Извлечение Аудиоисточника из объекта GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        // Находим объект Субтитров
        SubObj = GameObject.Find("SubtitresManager");
        Sub = SubObj.GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
     
        if (CanPlay== true && VoiceCanPlay.Play==0 )
        {
            VoiceCanPlay.Play = 1;
            SayToSub();   
            //Воспроизведение аудио, которое вы прикрепляете к компоненту AudioSource
            if(UseAudioSource) 
                m_MyAudioSource.Play(); 

           
            //запрещаем использовать более
            CanPlay = false;
        }
    }
    //sub - субтитры
    //Отображаем субьтитры, и выключаем их через время
    private void SayToSub()
    {
        Sub.text = "<b>" + WhoSaid + "</b>" + ": " + TextOfVoice;
        Invoke("DestroySub",time);
    }

    private void DestroySub()
    {
        Sub.text = "";
        VoiceCanPlay.Play = 0;
    }

}
