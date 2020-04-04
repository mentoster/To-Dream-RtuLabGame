using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerOnCall : MonoBehaviour
{
    // переменные для  необходимые для отчключения звонка
    public GameObject TurnOfSoundOfCall;
    private AudioSource _offSource;
    //проигрывания диалога
    AudioSource _mMyAudioSource;
    
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string[] sub = new string[13];
    private int _whatSubNow=0;
    
    // ауодио после диалога 
    public AudioClip GreatNowIMustFindComp;
    public AudioClip Ahhhhprogrammer;
    public AudioClip MotivationMusic;


    public GameObject Frolic;
    private SetMusicOrSound _setMusic;
    private bool _AlredyPressE=false;
    void Start()
    { 
        _mMyAudioSource = GetComponent<AudioSource>(); 
        _subObj = GameObject.Find("SubtitresManager");
        _sub = _subObj.GetComponent<TMP_Text>();
       _offSource=TurnOfSoundOfCall.GetComponent<AudioSource>();
       //необходимо для правильной регулировки звука в меню
       _setMusic = GetComponent<SetMusicOrSound>();
    }
    //Если Нажата клавиша в этой области, выполняем действие
    private void OnTriggerEnter(Collider other)
    {
        if(!_AlredyPressE)
        _sub.text = "Нажмите E, чтобы принять вызов";
    }

    private void OnTriggerStay(Collider other)
    {
        

        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE )
        {
            _offSource.enabled = false;
            _mMyAudioSource.Play();
            //прекращаем показывать игроку принять вызов
            _sub.text = "";
            _AlredyPressE = true;
            PlayDialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!_AlredyPressE)
            _sub.text = "";
    }
    // добавление субтитров по  таймингу 
    private void PlayDialog()
    {
        //через цикл не завернуть, время разное
        //диалог
        _mMyAudioSource.Play();
        Invoke("PlaySub",0);
        Invoke("PlaySub",4);
        Invoke("PlaySub",8);
        Invoke("PlaySub",11);
        Invoke("PlaySub",13);
        Invoke("PlaySub",18);
        Invoke("PlayNextFrase",20);
        Invoke("PlaySub",20);
        Invoke("PlaySub",26);
        Invoke("PlaySub",28);
        Invoke("PlayMotivationMusic",28);
        Invoke("PlaySub",80);
        Invoke("frolic",84);
        Invoke("AhhhhProgrammer", 98);
        Invoke("PlaySub",107);
        Invoke("PlaySub",111);
        Invoke("PlaySub",116);
    }

    
    //воспроизводства  массива субтитров
    private void PlaySub()
    {
        _sub.text = sub[_whatSubNow];
        _whatSubNow++;
    }
    //продолжение игры
    private void PlayNextFrase()
    {
        _mMyAudioSource.clip = GreatNowIMustFindComp;
        _mMyAudioSource.Play();
    }
    private void PlayMotivationMusic()
    {
        _setMusic.ItIsMusic= true;
        _mMyAudioSource.clip = MotivationMusic;
        _mMyAudioSource.Play();
    }

    private void frolic()
    {
        Frolic.SetActive(true);
    }
    private void AhhhhProgrammer()
    {
        PlaySub();
        Frolic.SetActive(false);
        _setMusic.ItIsMusic= false;
        _mMyAudioSource.clip = Ahhhhprogrammer;
        _mMyAudioSource.Play();
    }

}
