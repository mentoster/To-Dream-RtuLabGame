using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
  
    public GameObject[] enemyPref =new GameObject[1];
    public float maxTime;
    public float minTime;
    private float _timeBTWstart = 0;

    private void Update()
    {

        if (_timeBTWstart <= 0)
        {
            int enemyRND = Random.Range(0, enemyPref.Length);
            Instantiate(enemyPref[enemyRND], new Vector3(transform.position.x, transform.position.y,transform.position.z),Quaternion.identity);
            _timeBTWstart = Random.Range(minTime,maxTime);
        }
        else
        {
            _timeBTWstart -= Time.deltaTime;
        }
    }
}
