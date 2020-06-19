using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameState : MonoBehaviour
{
    public List<GameObject> girlsList = new List<GameObject>();

    [Header("Spawner_game_obj")] public GameObject spawner;

    private GameScore gameScore;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        gameScore = FindObjectOfType<GameScore>().GetComponent<GameScore>();
    }
    public void ChangeGirlState(int girlIndex)
    {
        for (int i = 0; i< girlsList.Count; i++)
        {
            girlsList[i].SetActive(false);
        }
        girlsList[girlIndex].SetActive(true);
    }

    public void StartSpawner()
    {
        spawner.GetComponent<ItemSpawner>().SetCanSpawn(true);
    }

    public void StopSpawner()
    {
        spawner.GetComponent<ItemSpawner>().SetCanSpawn(false);
    }

    public void RefreshGameScore()
    {
        gameScore.SetGameScore(100);
        scoreText.text = gameScore.GetGameScore().ToString();
    }

    
}
