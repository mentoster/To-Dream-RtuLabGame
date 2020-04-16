using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class AnswerOnCall : MonoBehaviour
{
    // переменные для  необходимые для отчключения звонка
     public GameObject turnOfSoundOfCall;
    private AudioSource _offSource;
    //проигрывания диалога
    AudioSource _mMyAudioSource;
    
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string[] sub = new string[13];
    private int _whatSubNow;
    
    // ауодио после диалога 
    public AudioClip greatNowIMustFindComp; 
    public AudioClip ahhhhprogrammer; 
    public AudioClip motivationMusic;


    public GameObject Frolic;
    private SetMusicOrSound _setMusic;
    private bool _alredyPressE=false;
    public GameObject party;
    void Start()
    { 
        _mMyAudioSource = GetComponent<AudioSource>(); 
        _subObj = GameObject.Find("SubManager");
        _sub = _subObj.GetComponent<TMP_Text>();
       _offSource=turnOfSoundOfCall.GetComponent<AudioSource>();
       //необходимо для правильной регулировки звука в меню
       _setMusic = GetComponent<SetMusicOrSound>();
    }
    //Если Нажата клавиша в этой области, выполняем действие
    private void OnTriggerEnter(Collider other)
    {
        if(!_alredyPressE)
            _sub.text = "Нажмите E, чтобы принять вызов";
    }

    private void OnTriggerStay(Collider other)
    {
        

        if ( Input.GetKeyDown( KeyCode.E ) && !_alredyPressE )
        {
            party.SetActive(false);
            _offSource.enabled = false;
            _mMyAudioSource.Play();
            //прекращаем показывать игроку принять вызов
            _sub.text = "";
            _alredyPressE = true;
            PlayDialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!_alredyPressE)
            _sub.text = "";
    }
    // добавление субтитров по  таймингу 
    private void PlayDialog()
    {
        //через цикл не завернуть, время разное
        //диалог
        _mMyAudioSource.Play();
        Statics.AudioNowPlay = 1;
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
        _mMyAudioSource.clip = greatNowIMustFindComp;
        _mMyAudioSource.Play();
    }
    private void PlayMotivationMusic()
    {
        _setMusic.ItIsMusic= true;
        _mMyAudioSource.clip = motivationMusic;
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
        _mMyAudioSource.clip = ahhhhprogrammer;
        _mMyAudioSource.Play();
        //активируем взаимодействие с предметами
        Statics.AudioNowPlay = 0;
        Statics.level=1;
        Debug.Log("Уровень сейчас " + Statics.level);
    }

}
