using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Catches : MonoBehaviour
{
    public GameObject gameState;

    public GameObject pointsEffect1;

    public int stateIndex;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int itemIndex = collision.gameObject.GetComponent<Item>().GetNeedIndex();
        if (stateIndex == itemIndex)
        {
            Destroy(collision.gameObject);
            PointsEffect100();
            UpdateScore();
        }
    }

    private void PointsEffect100()
    {
        GameObject effect = Instantiate(pointsEffect1, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    private void UpdateScore()
    {
        GameState gs = gameState.GetComponent<GameState>();
        
        gs.RefreshGameScore();


    }
}
