
using UnityEngine;


using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{

    public void RestartLevel()
    {   
        Time.timeScale = 1f;   
        Debug.Log("Restarted GameStart...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
    }
}
