using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject gameState;

   

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameState states = gameState.GetComponent<GameState>();

        states.StopSpawner();
        states.GameLoose();
        //Destroy(collision.gameObject);

        
    }
}
