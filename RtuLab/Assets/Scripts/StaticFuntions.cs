using UnityEngine;

public static class Statics
{

    //менеджер звука
    // 0 - не играет звук
    // 1 играет
    public static int AudioNowPlay { get; set; }

    //проверка на количество предметов
    // детали компьютера которые необходимо найти - 
    // монитор
    // динамики * 2
    // системный блок
    // микросхемы
    // провода
    // стул
    // подушка
    // кулер 
    //Функция равна не равная 0 означает, что можно активировать эти предметы
    public static int HowManyItems { get; set; }
    public static int level
    {
        get => PlayerPrefs.GetInt("level");
        set => PlayerPrefs.SetInt("level", value);
    }

}


