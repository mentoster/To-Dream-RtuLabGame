using TMPro;
using UnityEngine;

//этот код отвечает за то, чтобы воспроизводился звук при поподании в определенную область 
public class PlayVoice : MonoBehaviour
{
    AudioSource _mMyAudioSource;
    //кто говорит 
    public int LevelMax;
    public string whoSaid;
    //Добавляем субтитры
    public string textOfVoice;
    //Где будут Воспроизводится субтитры
    private  GameObject _subObj;

    private TMP_Text _sub;
    //время для субтитров
    public float time;

     public bool useAudioSource=true;

    //Использовании m_ToggleChange гарантирует, что звук не воспроизводится несколько раз
    private  bool CanPlay=true;
    void Start()
    {
        //Извлечение Аудиоисточника из объекта GameObject
        _mMyAudioSource = GetComponent<AudioSource>();
        // Находим объект Субтитров
        _subObj = GameObject.Find("SubManager");
        _sub = _subObj.GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
     
        if (CanPlay == true && Statics.AudioNowPlay==0 && Statics.level <=LevelMax)
        {
            Statics.AudioNowPlay = 1;
            SayToSub();   
            //Воспроизведение аудио, которое вы прикрепляете к компоненту AudioSource
            if(useAudioSource) 
                _mMyAudioSource.Play(); 

           
            //запрещаем использовать более
            CanPlay = false;
        }
    }
    //sub - субтитры
    //Отображаем субтитры, и выключаем их через время
    private void SayToSub()
    {
        _sub.text = "<b>" + whoSaid + "</b>" + ": " + textOfVoice;
        Invoke("DestroySub",time);
    }

    private void DestroySub()
    {
        _sub.text = "";
        Statics.AudioNowPlay = 0;
    }

}
