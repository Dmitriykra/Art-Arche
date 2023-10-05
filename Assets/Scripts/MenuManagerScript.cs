using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField] private Button startGame;
    private int sceneIndex;

    private void Start()
    {
        sceneIndex = PlayerPrefs.GetInt(Constants.levelIndex, 0);
        if (sceneIndex.Equals(0)) sceneIndex++;
    }

    //call in start game button 
    public  void StartGame()
    {
        Invoke(nameof(LoadFirstLevel), 0.5f);
    }


    public void RateUs()
    {
        Invoke(nameof(OpenUrlRate), 0.5f);
    }

    void OpenUrlRate()
    {
        var packageName = Application.identifier;
        var iOSAppStoreURL = Constants.iOSAppStoreURL + packageName;
        Debug.Log(iOSAppStoreURL);
        Application.OpenURL(iOSAppStoreURL);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        Invoke(nameof(AppQuit), 0.5f);
    }

    void AppQuit()
    {
        Application.Quit();
    }
}

