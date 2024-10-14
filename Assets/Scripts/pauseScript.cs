using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    private bool isGamePaused = false;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void pauseTheGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            isGamePaused = true;
        }
        else { resumeTheGame(); }

    }
    public void resumeTheGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        isGamePaused = false;
    }
    public void quitTheGame()
    {
        SceneManager.LoadScene("start");
    }
}
