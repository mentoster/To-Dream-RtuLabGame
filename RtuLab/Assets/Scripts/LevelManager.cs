using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    private void Start()
    {
        Statics.level = level;
    }
}
