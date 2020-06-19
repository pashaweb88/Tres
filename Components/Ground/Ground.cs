using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject gameState;

    public GameObject currnetLifeIcon;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameState states = gameState.GetComponent<GameState>();

        states.StopSpawner();
        
        Destroy(collision.gameObject);

        currnetLifeIcon.GetComponent<Life>().LoseLifeEffect();
    }
}
