using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public GameManager CoinPoints;

    // Start is called before the first frame update
    void Start()
    {

        CoinPoints = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads player back into game scene and resets score to 0
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        CoinPoints.playerScore = 0;
    }

    //Exits the application when button is pressed
    public void QuitGame()
    {
        Debug.Log("Quitting Game");

        Application.Quit();

    }

}
