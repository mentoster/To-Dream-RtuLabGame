using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using TMPro;

using UnityEngine.SceneManagement;
 public class ExitButton : MonoBehaviour
 {
     public void ToGame()
     {
         Debug.Log("Start game");
         SceneManager.LoadScene("Game");
     }
     public void ToHome()
     {
         Time.timeScale = 1f;   
         Debug.Log("Back to home...");
         SceneManager.LoadScene("Home");
     }
     public void Quiet()
     {
         Application.Quit();
         Debug.Log("Exit pressed ");
         Time.timeScale = 1f;
     }
 }