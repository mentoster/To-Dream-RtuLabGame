using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//данный кот отвечает за проверку нахождения всех предметов, ставится на стол, где стоит компьютер. 
public class CheckIfHaveAllItem : MonoBehaviour
{
    //Переменные неоходимые для субтитров
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string[] sub=new string[2];
    // блокировка лишнего нажатия на E
    public bool _AlredyPressE=false;
    public GameObject miniGame;
    public GameObject windowsMonitor;
    public GameObject spawn;
    public GameObject party;
    public GameObject PC;
    
    
    void Start()
    {
        _subObj = GameObject.Find("SubManager");
        _sub = _subObj.GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter(Collider other)
        {   
            #region triggerEnterRegion
            
            //если у нас необходимое количество предметов, и текущий уровень 1, то показать субтитр 1
            if (!_AlredyPressE && Statics.HowManyItems >= 7 && Statics.level == 1)
            {
                _sub.text = sub[0];
            }  
            
            //если у не все предметы нашёл
            if (!_AlredyPressE && Statics.HowManyItems < 7 && Statics.level==1   )
            {
                int buff = 7 - Statics.HowManyItems;
                _sub.text = $"Не хватает {buff} предметов для сбора компьютера";
            }
            // когда игрок завершил пазл, показывать субтитр 1
            if (!_AlredyPressE  && Statics.level == 2)
            {
                _sub.text = sub[1];
            }  
            // когда игрок завершил мини игру бег, показывать субтитр 2
            if (!_AlredyPressE && Statics.level == 3)
            {
                _sub.text = sub[2];
            } 
            #endregion
        }

       private void OnTriggerStay(Collider other)
    {
         #region triggerStayRegion
         
         //если игрок собрал все предметы, то можно запускать игру пазлы
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.HowManyItems==7 && Statics.level==1)
        {
            _AlredyPressE = true;
            _sub.text = "";
            SceneManager.LoadScene("Puzzles");
            Debug.Log("Загрузка мини игры - пазлы");

        }
        
        //это часть когда выполняется, после того как игрок выйграл пазлы, он "включает компьютер"
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.level==2)
        {
            _sub.text = "";
            _AlredyPressE = true;
            windowsMonitor.SetActive(true);
            Invoke("StartMiniGame",4);
        }
        
        //если игрок все игры завершил, то он запускает игру в компьютере, тем самым игра зацикливается, перезапускается уровень
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.level == 3)
        {
            
            PC.SetActive(true);
            Statics.level = 4;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
            _sub.text = "";
        }   
        #endregion
               
    }
       // игрок вышел из зоны предмета, значит мы обнуляем коментарий.
 private void OnTriggerExit(Collider other)
    {
        if(Statics.level>0)
        _sub.text = "";
    }
 
   //функция запускаяет игру минибег
    private void StartMiniGame()
    {
        //атаки начинаются не сразу
        Invoke("StartSpawn",3);
        windowsMonitor.SetActive(false);
        miniGame.SetActive(true);
    }

    private void StartSpawn()
    {
        spawn.SetActive(true);
    }
}
