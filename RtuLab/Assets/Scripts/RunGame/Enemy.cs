using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float damage;
   public float speed;

   private void FixedUpdate()
   {
      transform.Translate(Vector2.left*speed);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.CompareTag("Player"))
      {
         collision.GetComponent<UnityPlayerController>().ApplyDamage(damage);
      }
      Destroy(gameObject);
   }
}
