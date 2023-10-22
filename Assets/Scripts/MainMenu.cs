using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Click;
    public AudioClip ClickSound;
    public GameObject OptionsCanvas;
    public GameObject MainMenuCanvas;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;
    }

    public void OnClick()
    {
        Click.PlayOneShot(ClickSound);
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
