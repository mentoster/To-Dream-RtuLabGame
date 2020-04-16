using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParametrs : MonoBehaviour
{
    public bool deleteSave;
    public bool changeLevel;
    public int level;
    public GameObject party;
    public GameObject objectForPC;
    public GameObject pc;
    public GameObject player;
    public GameObject call;
    void Start()
    {   
        Statics.AudioNowPlay = 0;
        Statics.HowManyItems = 0;
                 
        if (!PlayerPrefs.HasKey("level"))
        {
            Statics.level = -1;
        }

        if (deleteSave)
        {
            Statics.level = -1;
        }
        Debug.Log("Уровень сейчаc" + Statics.level);
        if (changeLevel)
        {
            Statics.level = level;
            Debug.Log("Уровень сейчаc" + Statics.level);
        }
        
        //задаём стартовые параметры при выходе из игры пазлы
    
        if (Statics.level == 1)
        {
         call.SetActive(false);
        }
      
        if (Statics.level == 2)
        {
            objectForPC.SetActive(false);
            pc.SetActive(true);
            player.transform.position=new Vector3(12.75f, 1f,19.26f);
        }
        if (Statics.level == 4)
        {
            Statics.level = -1;
          party.SetActive(true);
        }
      
    }
    
}
