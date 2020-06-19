using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    private int gameScore;

    private void Start()
    {
        gameScore = 0;
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
