using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
//этот код отвечает за количество  загрузки игры
public class HealthManager : MonoBehaviour
{

   public float health=0;
  public TMP_Text loadProccessText;
   public float healthSpeed;
   public GameObject Error;
   public GameObject MiniGame;
   public GameObject Win;
   public GameObject tableForPC;
   private void FixedUpdate()
   {
      health+=healthSpeed;
      upHealthText();
   }

   public void upHealthText()
   {
      if (health < 0)
      {
         Error.SetActive(true);
         health = 0;
         MiniGame.SetActive(false);
        Invoke("ErrorOff",3);
      }

      if (health > 100)
      {
         tableForPC.GetComponent<CheckIfHaveAllItem>()._AlredyPressE = false;
         Win.SetActive(true);
         Error.SetActive(false);
         MiniGame.SetActive(false);
         Statics.level=3;
      }
      loadProccessText.text = $"Программируется игра.. \n  Прогресс {Mathf.Round(health)}%";
   }
//убираем экран через время
   private void ErrorOff()
   {
      Error.SetActive(false);
      tableForPC.GetComponent<CheckIfHaveAllItem>()._AlredyPressE = false;
   }
}
