using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeLimit = 300.0f; // Time limit in seconds (adjust as needed)
    public int trapsToDisable = 10; // Number of traps to disable for victory

    private float currentTime;
    public static int trapsDisabled = 0;
    private bool isGameWon = false;

    // Start is called before the first frame update
    void Start()
    {
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
        timerText.text = string.Format("Time: {0:00}:{1:00}" + " " + "Traps "+ trapsDisabled + "/8", minutes, seconds);
    }

    // Handle game over (win or lose)
    void GameOver(bool win)
    {
        isGameWon = win;
        if (isGameWon)
        {
            // Handle win (e.g., show win screen)
            Debug.Log("You won!");
        }
        else
        {
            // Handle lose (e.g., show lose screen)
            Debug.Log("You lost!");
        }

        // You can add more actions here, such as reloading the scene or going to a game over screen.
    }
}