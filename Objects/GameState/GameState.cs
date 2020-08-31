using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class GameState : MonoBehaviour
{
    [Header("Number of next sceen with loose")] public int nextSceneIndex;
    public bool Tutor = true;

    public List<GameObject> girlsList = new List<GameObject>();

    [Header("Spawner_game_obj")] public GameObject spawner;

    private GameScore gameScore;

    public TextMeshProUGUI scoreText;

    public GameObject smokeEffectObject;

    public GameObject currnetLifeIcon;

    public AudioClip lvlBg;
    public AudioClip catchSound;
    public AudioClip missSound;
    public AudioClip looseLifeSound;
    [Range(0,1)] public float soundsVolume = 0.5f;




    private int CatchCounter = 0;

    private const string bannerAd = "ca-app-pub-6091822131827669/2106228594";
    private const string startAd  = "ca-app-pub-6091822131827669/2653023507";
    private InterstitialAd ad;

    private void PlaySounds(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, soundsVolume);
    }


    private void Start()
    {
        ad = new InterstitialAd(startAd);
        AdRequest req = new AdRequest.Builder().Build();
        ad.LoadAd(req);
        ad.OnAdLoaded += OnAdLoaded;
        
        gameScore = FindObjectOfType<GameScore>().GetComponent<GameScore>();
       
        if (gameScore.GetGameScore() != 0)
        {
            scoreText.text = gameScore.GetGameScore().ToString();
        }

        PlaySounds(lvlBg);


        
        
    }

    private void OnAdLoaded(object sender, EventArgs e)
    {
        ad.Show();
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
        if (!Tutor)
        {
            spawner.GetComponent<ItemSpawner>().SetCanSpawn(true);
        }

        BannerView bannerV = new BannerView(bannerAd, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerV.LoadAd(request);

    }

    

    public void StopSpawner()
    {
        spawner.GetComponent<ItemSpawner>().SetCanSpawn(false);
    }

    public void DoHardestTimer()
    {
        spawner.GetComponent<ItemSpawner>().GoHarder();
        PlaySounds(catchSound);
    }

    public void RefreshGameScore()
    {
        gameScore.SetGameScore(100);
        scoreText.text = gameScore.GetGameScore().ToString();
    }

    public void GameLoose()
    {
        StartCoroutine(LooseLifeAnimation());

        Item[] itemsOnScene = FindObjectsOfType<Item>();

        for (int i = 0; i< itemsOnScene.Length; i++)
        {
            var smokeEffect = Instantiate(smokeEffectObject, itemsOnScene[i].transform.position, Quaternion.identity) as GameObject;
            itemsOnScene[i].DestroyItem();
            Destroy(smokeEffect, 1f);
            StartCoroutine(LooseLifeAnimation());
            StartCoroutine(LoadNextLevel());
            PlaySounds(missSound);
        }
    }

    //private void LooseLifeAnimation()
    //{
    //    currnetLifeIcon.GetComponent<Life>().LoseLifeEffect();
    //}

    IEnumerator LooseLifeAnimation()
    {
        yield return new WaitForSeconds(1f);
        currnetLifeIcon.GetComponent<Life>().LoseLifeEffect();
        PlaySounds(looseLifeSound);
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(nextSceneIndex);
        
    }



}
