using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource SFX;
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

    public void Music_ON_OFF()
    {
        if (Music.volume > 0) Music.volume = 0;
        else Music.volume = 1;
    }
    public void SFX_ON_OFF()
    {
        if (SFX.volume > 0) SFX.volume = 0;
        else SFX.volume = 1;
    }
    public void quitTheGame()
    {
        SceneManager.LoadScene("start");
    }
}
