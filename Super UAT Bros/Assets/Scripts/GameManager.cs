using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public int currentScene = 0;

    public int playerScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Warning: A second game manager was detected and destroyed.");
        }
    }

    /// <summary>
    /// Load the scene passed in as a parameter.
    /// </summary>
    /// <param name="levelToLoad">Name of the level to load.</param>
    public void LoadLevel(string levelToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
        // Potentially Dangerous
        currentScene++;
    }

    public void LoadLevel(int indexToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene + 1);
    }

    //Exits the application when button is pressed
    public void QuitGame()
    {

        Application.Quit();

    }
}
