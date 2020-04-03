using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerOnCall : MonoBehaviour
{
    public GameObject TurnOfSoundOfCall;
    AudioSource _mMyAudioSource;
    private  GameObject _subObj;
    private TMP_Text _sub;
    private AudioSource _offSource;
    public string[] sub = new string[6];
    private int _whatSubNow=0;
    private bool _AlredyPressE=false;
    void Start()
    { 
        _mMyAudioSource = GetComponent<AudioSource>(); 
        _subObj = GameObject.Find("SubtitresManager");
        _sub = _subObj.GetComponent<TMP_Text>();
       _offSource=TurnOfSoundOfCall.GetComponent<AudioSource>();
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

    private void PlayDialog()
    {
        _mMyAudioSource.Play();
        Invoke("PlaySub",0);
        Invoke("PlaySub",4);
        Invoke("PlaySub",8);
        Invoke("PlaySub",11);
        Invoke("PlaySub",13);
        Invoke("PlaySub",18);
    }

    private void PlaySub()
    {
        _sub.text = sub[_whatSubNow];
        _whatSubNow++;
    }


}
