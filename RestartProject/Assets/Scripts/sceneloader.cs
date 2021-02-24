using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
