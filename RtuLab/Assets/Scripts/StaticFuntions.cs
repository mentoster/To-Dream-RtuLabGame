using UnityEngine;
//статические функции 
//отвечают за то, чтобы звук не накладывался (не везде успел поставить ограничение)
//второе необходимо для облегчения сохранения игры
public static class Statics
{

    //менеджер звука
    // 0 - не играет звук
    // 1 играет
    public static int AudioNowPlay { get; set; }

    //проверка на количество предметов

    public static int HowManyItems { get; set; }
    public static int level
    {
        get => PlayerPrefs.GetInt("level");
        set => PlayerPrefs.SetInt("level", value);
    }


}


