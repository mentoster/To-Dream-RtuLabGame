using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParametrs : MonoBehaviour
{

    void Start()
    {     //задаём стартовые параметры
        Statics.AudioNowPlay = 0;
        Statics.HowManyItems = 0;
        if (!PlayerPrefs.HasKey("level"))
        {
            Statics.level = 0;
        }
    }
    
}
