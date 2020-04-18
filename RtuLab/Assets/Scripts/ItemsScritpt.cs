using TMPro;
using UnityEngine;
    //этот скрипт вешается на предметы, которые нобходимо собрать
public class ItemsScritpt : MonoBehaviour
{
    //Переменные неоходимые для субтитров
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string[] sub = new string[1];
    public GameObject thisObject;
    public int subtime;
    // блокировка лишнего нажатия на E
    private bool _alredyPressE=false;
    
    //звук взятия предмета
   public AudioSource takeSound;
   public AudioSource whenTakeVoice;
   public string whoSay = "Дмитрий";
   public bool useAudoSource=true;

    private GameObject _gameManager;
    void Start()
    {
        _subObj = GameObject.Find("SubManager");
        _sub = _subObj.GetComponent<TMP_Text>();
        _gameManager=GameObject.Find("GameManagers");
    }

    private void OnTriggerEnter(Collider other)
    {
        //чекаем уровень 
        if (!_alredyPressE && Statics.level == 1 )
        {
            _sub.text = sub[0];
        }
    }
    private void OnTriggerStay(Collider other)
    {
     //позваоляем взять игроку
        if ( Input.GetKeyDown( KeyCode.E ) && !_alredyPressE && Statics.level==1)
        {
            if (useAudoSource)
            {
                whenTakeVoice.Play();
                Statics.AudioNowPlay = 1;
                _gameManager.GetComponent<DeleteSub>().deleteSub(sub[1],subtime);
            }
            takeSound.Play();
            _alredyPressE = true;
            //повышаем количество вещей в инвертаре
            Statics.HowManyItems++;
            Debug.Log($"Взят предмет! теперь их {Statics.HowManyItems}");
            Invoke(nameof(DeleteSub),subtime);
            Destroy(thisObject);
    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(Statics.level==1)
            _sub.text = "";
    }
    
   
    
}
