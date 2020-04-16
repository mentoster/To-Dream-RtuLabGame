using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnityPlayerController : MonoBehaviour
{
   Rigidbody2D m_Rigidbody;
   public Vector2 jumpHeight;
   bool inAir=false;
   AudioSource _jumpsound;
   public GameObject healthUp;
   void Start()
   {
      _jumpsound = GetComponent<AudioSource>();
      m_Rigidbody = GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      
          if (Input.GetKey(KeyCode.Mouse0) && !inAir)
          {
       _jumpsound.Play();
              inAir = true;
              m_Rigidbody.AddForce(jumpHeight);
          }
      
   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
      inAir = false;
   }

   public void  ApplyDamage(float damage)
   {
      //вычитаем единицу, так как при срабатыванни функции upHealth прибавляется единица
      healthUp.GetComponent<HealthUp>().health-=damage;
      healthUp.GetComponent<HealthUp>().upHealthText();
   }
}
