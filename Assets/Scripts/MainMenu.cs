using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject OptionsCanvas;
    public GameObject MainMenuCanvas;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); ;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); ;
    }



    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ShowOptions()
    {
        OptionsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    } 
    public void HideOptions()
    {
        OptionsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }


}
