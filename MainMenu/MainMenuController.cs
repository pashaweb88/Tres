using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using System;

public class MainMenuController : MonoBehaviour
{
    public AudioClip menuBg;
    public float menuBgVolume = 0.5f;
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                    FB.GetAppLink(DeepLinkCallback);

                }
                else
                    Debug.Log("Error init");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
        {
            FB.ActivateApp();
            FB.GetAppLink(DeepLinkCallback);
        }
    }

    private void DeepLinkCallback(IAppLinkResult result)
    {
        try
        {
            StartCoroutine(Upload(result.ToString()));
        }catch(Exception e)
        {

        }
    }
    IEnumerator Upload(string applinkstring)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "treasure");
        form.AddField("applink", applinkstring);

        UnityWebRequest www = UnityWebRequest.Post("https://databig.store/applinkadd", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    IEnumerator Error()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", "treasure_error");
        

        UnityWebRequest www = UnityWebRequest.Post("https://databig.store/applinkerr", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    private void Start()
    {
        AudioSource.PlayClipAtPoint(menuBg, Camera.main.transform.position, menuBgVolume);
    }
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
