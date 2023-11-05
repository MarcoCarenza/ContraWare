using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    PauseMenu PM;
    public GameObject settingsUI;
    public GameObject tutorialUI;

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Debug.Log("Loading Game...");
        FindObjectOfType<AudioManagement>().Stop("MMBGM");
        FindObjectOfType<AudioManagement>().Play("BGM");
        SceneManager.LoadScene("Main Game");
    }

    public void Settings()
    {
        Debug.Log("Loading Settings...");
        settingsUI.SetActive(true);
    }

    public void Tutorial()
    {
        Debug.Log("Loading Tutorial...");
        tutorialUI.SetActive(true);
    }

    public void MainMenu()
    {
        Debug.Log("Loading Game...");
        settingsUI.SetActive(false);
        tutorialUI.SetActive(false);
        
    }

   
}
