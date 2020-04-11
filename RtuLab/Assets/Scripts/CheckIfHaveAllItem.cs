using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfHaveAllItem : MonoBehaviour
{
    //Переменные неоходимые для субтитров
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string sub;
    // блокировка лишнего нажатия на E
    private bool _AlredyPressE=false;

    void Start()
    {
        _subObj = GameObject.Find("SubManager");
        _sub = _subObj.GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //
        //
        if (!_AlredyPressE && Statics.HowManyItems >= 7 && Statics.level == 1)
        {
            _sub.text = sub;
        }  
        if (!_AlredyPressE &&Statics.level==1&& Statics.HowManyItems < 7 )
        {
            int buff = 7 - Statics.HowManyItems;
            _sub.text = $"Не хватает {buff} предметов для сбора компьютера";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if ( Input.GetKeyDown( KeyCode.E ) && !_AlredyPressE && Statics.HowManyItems==7 && Statics.level==1)
        {

            _sub.text = "";
            SceneManager.LoadScene("Puzzles");
            Debug.Log("Загрузка мини игры - пазлы");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _sub.text = "";
    }
}
