using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public GameManager points;

    public void Start()
    {

        points = FindObjectOfType<GameManager>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the game object that entered the trigger is our player, then load the next level.
        if (other.gameObject.name == "Player" && points.playerScore == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
