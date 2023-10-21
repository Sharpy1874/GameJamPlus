using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Click;
    public AudioClip ClickSound;
    public GameObject Options;
    public GameObject MainCanvas;
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
        Options.SetActive(true);
        MainCanvas.SetActive(false);
    } 
    public void HideOptions()
    {
        Options.SetActive(false);
        MainCanvas.SetActive(true);
    }


}
