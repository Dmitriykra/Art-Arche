using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject pause;
    public GameObject restart;
    public bool isPlayble;

    private void Start()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        restart.SetActive(false);
    }
    public void StratGame()
    {
        Time.timeScale = 1;
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
        isPlayble = false;
        SceneManager.LoadScene(0);
    }
}
