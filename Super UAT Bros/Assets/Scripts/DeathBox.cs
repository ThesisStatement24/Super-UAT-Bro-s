using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {

       
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    //Takes 1 life from player on collision and respawns the player at respawn location
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            player.maxHP--;
            player.Respawn();

        }

    }

}
