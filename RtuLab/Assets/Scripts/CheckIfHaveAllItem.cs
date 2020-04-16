using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!_AlredyPressE && Statics.HowManyItems >= 7 && Statics.level == 1)
        {
            _sub.text = sub[0];
        }  
        if (!_AlredyPressE &&Statics.level==1 && Statics.HowManyItems < 7 )
        {
            int buff = 7 - Statics.HowManyItems;
            _sub.text = $"Не хватает {buff} предметов для сбора компьютера";
        }
        if (!_AlredyPressE  && Statics.level == 2)
        {
            _sub.text = sub[1];
        }  
        if (!_AlredyPressE && Statics.level == 3)
        {
            _sub.text = sub[2];
        }  
    }
    private void OnTriggerStay(Collider other)
    {
        
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.HowManyItems==7 && Statics.level==1)
        {
            _AlredyPressE = true;
            _sub.text = "";
            SceneManager.LoadScene("Puzzles");
            Debug.Log("Загрузка мини игры - пазлы");

        }
        
        
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.level==2)
        {
            _sub.text = "";
            _AlredyPressE = true;
            windowsMonitor.SetActive(true);
            Invoke("StartMiniGame",4);
        }
        
        
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.level == 3)
        {
            
            PC.SetActive(true);
            Statics.level = 4;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
            _sub.text = "";
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if(Statics.level>0)
        _sub.text = "";
    }

    private void StartMiniGame()
    {
        Invoke("StartSpawn",3);
        windowsMonitor.SetActive(false);
        miniGame.SetActive(true);
    }

    private void StartSpawn()
    {
        spawn.SetActive(true);
    }
}
