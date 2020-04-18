using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//этот  код отвечает за то, чтобы менять цвет диско в финале игры
// метод invoke не очень оптимизированный, и я это знаю, да и код можно было сократить до цикла
// но зачем?))))) нарушится понимание
// Для справки, для лучшей оптимизации переписать код чере Coroutines instead. Читать об этом в документации
public class LightColorChanger : MonoBehaviour
{
  private Light disco;

  private void Start()
  {
    disco = GetComponent<Light>();
    red();
  }

 

  private void red()
  {
      disco.color=Color.red;
      Invoke("blue",0.5f);
  }
 
  private void blue()
  {
      disco.color=Color.blue;
      Invoke("green",0.5f);
  }
  private void green()
  {
      disco.color=Color.green;
      Invoke("magent",0.5f);
  }
  private void magent()
  {
      Invoke("red",0.5f);
      disco.color=Color.magenta;
  }
}
