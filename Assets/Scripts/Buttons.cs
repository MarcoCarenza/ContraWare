using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    PauseMenu PM;

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene("Main Game");
        
    }

    public void Settings()
    {
        Debug.Log("Loading Settings...");
        SceneManager.LoadScene("Settings");
    }

    public void Tutorial()
    {
        Debug.Log("Loading Tutorial...");
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenu()
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene("Main Menu");
    }

   
}
