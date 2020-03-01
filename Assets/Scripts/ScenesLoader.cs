using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class ScenesLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void LoadStartLevel()
    {
        GameRecord gameRecordComponent = FindObjectOfType<GameRecord>();
        Destroy(gameRecordComponent.gameObject);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
