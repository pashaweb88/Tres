using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockIndex;

    public GameObject gameState;

    private SpriteRenderer blockSprite;

    private float animationSpeed = 2f;

    
    
    private void OnMouseDown()
    {
        gameState.GetComponent<GameState>().ChangeGirlState(blockIndex);
        StartCoroutine(OnMouseDownAnimation());
    }

    IEnumerator OnMouseDownAnimation()
    {
        blockSprite = GetComponent<SpriteRenderer>();
        
        for (float i = 1; i > 0.8f; i -= Time.deltaTime*animationSpeed)
        {
            ChangeSpriteColor(i);
            yield return null;
        }
        for (float i = 0.8f; i < 1f; i += Time.deltaTime * animationSpeed)
        {
            ChangeSpriteColor(i);
            yield return null;
        }
        ChangeSpriteColor(1f);
    }

    private void ChangeSpriteColor(float alpha)
    {
        blockSprite.color = new Color(alpha, alpha, alpha, 1f);
    }

    
}
