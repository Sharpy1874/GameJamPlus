using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeLimit = 10.0f; // Time limit in seconds (adjust as needed)
    public int trapsToDisable = 3; // Number of traps to disable for victory
    private float currentTime;
    public static int trapsDisabled = 0;
    private bool isGameWon = false;
    public RawImage rawImage;
    public Texture NewTexture;
    public GameObject inGamePanel;
    public GameObject LoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        currentTime = timeLimit;
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameWon)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                // Handle game over (e.g., show lose screen)
                GameOver(false);
                inGamePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
            }

            UpdateTimerDisplay();
        }
        if (trapsDisabled >= trapsToDisable)
        {
            // Handle game win (e.g., show win screen)
            GameOver(true);
        }
    }

    // Call this function when a trap is disabled
    public void TrapDisabled()
    {
        trapsDisabled++;

        if (trapsDisabled >= trapsToDisable)
        {
            // Handle game win (e.g., show win screen)
            GameOver(true);
        }
    }

    // Update the timer display
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}" + " " + "Traps "+ trapsDisabled + "/" + trapsToDisable, minutes, seconds);
    }

    // Handle game over (win or lose)
    public void GameOver(bool win)
    {
        isGameWon = win;
        if (isGameWon)
        {
            // Handle win (e.g., show win screen)
            rawImage.texture = NewTexture;
            timerText.text = "Find: 1 / 0";

        }
        else
        {
            LoseScreen.SetActive(true);
            Time.timeScale = 0f;
            // Handle lose (e.g., show lose screen)
            Debug.Log("You lost!");
        }

        // You can add more actions here, such as reloading the scene or going to a game over screen.
    }
}
