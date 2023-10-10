
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject pause;
    public GameObject restart;
    public bool isPlayble;
    private int _taskForLevel = 3;

    private void Start()
    {
        pause.SetActive(false);
        restart.SetActive(false);
    }
    public void StratGame()
    {
        Time.timeScale = 1;
        DecreaseTntCount(0);
        playBtn.SetActive(false);
        isPlayble = true;
        pause.SetActive(true);
        restart.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (!isPlayble)
        {
            StratGame();
        }
        else
        {
            isPlayble = false;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    
    public void GoToMenu()
    {
        isPlayble = false;
        SceneManager.LoadScene(0);
    }
    
    public void DecreaseTntCount(int i)
    {
        Debug.Log("Task for level " + _taskForLevel);
        
        _taskForLevel --;

        if (_taskForLevel == 0)
        {
            LoadNextLevel();
        }
        else if(_taskForLevel==0)
        {
            _taskForLevel = 3;
        }
        
        
    }
    
    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene < 3)
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            currentScene = 0;
            SceneManager.LoadScene(currentScene);
        }
        
    }
}
