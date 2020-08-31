using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    
    private int gameScore = 0;


    private void Awake()
    {
        int gameScoreCount = FindObjectsOfType<GameScore>().Length;

        if (gameScoreCount > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetGameScore(int score)
    {
        gameScore += score;
    }

    public int  GetGameScore()
    {
        return gameScore;
    }
}
