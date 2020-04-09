using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterCallCollectDetails : MonoBehaviour
{
    //детали компьютера которые необходимо найти - 
    // монитор
    // динамики
    // системный блок
    // микросхемы
    // провода
    //стул
    //подушка
    private  GameObject _subObj;
    private TMP_Text _sub;
    public string sub;
    private bool _AlredyPressE=false;
  
    void Start()
    {
        _subObj = GameObject.Find("SubtitresManager");
        _sub = _subObj.GetComponent<TMP_Text>();
    }
     private void OnTriggerEnter(Collider other)
     {
            if(!_AlredyPressE)
                _sub.text = sub;
     }
     private void OnTriggerExit(Collider other)
     {
         if(!_AlredyPressE)
             _sub.text = "";
     }
}
