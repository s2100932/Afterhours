using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
     public Values sanityValues;   

    void Update()
    {
        if (sanityValues.sanity >= 150f)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {

        Time.timeScale = 1f;

       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
