using System;
using TMPro;
using UnityEngine;
 //этот код отвечает за  то, чтобы отобразить  посылаемый суда текст в субтитры и удалить его через время
public class DeleteSub : MonoBehaviour
{
 public TMP_Text sub;
 private  GameObject _subObj;
 private TMP_Text _sub;
 private void Start()
 {
  _subObj = GameObject.Find("SubManager");
  _sub = _subObj.GetComponent<TMP_Text>();
 }

 //другие коды вызывют эту функцию, посылают суда  текст и время удаления
 public void deleteSub(string text,int time)
 {
  Statics.AudioNowPlay = 1;
  _sub.text =   "<b>" + "Дмитрий" + "</b>" + ": " + text;
  Invoke(nameof(Delete),time);
 }

 private void Delete()
 {
  sub.text = "";
  Statics.AudioNowPlay = 0;
 }
 
}
