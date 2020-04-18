using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using TMPro;

using UnityEngine.SceneManagement;
 public class ExitButton : MonoBehaviour
 {
  
  
     public void Quiet()
     {
         Application.Quit();
         Debug.Log("Exit pressed ");
         Time.timeScale = 1f;
     }
 }