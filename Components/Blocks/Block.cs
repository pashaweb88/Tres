using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockIndex;
    public GameObject gameState;

    


    
    private void OnMouseDown()
    {
        
        
        gameState.GetComponent<GameState>().ChangeGirlState(blockIndex);
    }

    
}
