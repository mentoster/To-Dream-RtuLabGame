using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
