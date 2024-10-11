using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }
    public void pauseTheGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void resumeTheGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void quitTheGame()
    {
        SceneManager.LoadScene("start");
    }
}
