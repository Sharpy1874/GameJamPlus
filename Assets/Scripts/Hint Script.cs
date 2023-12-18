using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HintController : MonoBehaviour
{
    public float activationTime = 5f; // Set the time in seconds required to activate the hint
    public float cooldownTime = 10f; // Set the cooldown time in seconds for each hint
    [SerializeField] TMP_Text textChange;
    [SerializeField] GameObject text;
    private bool hintUsed = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Display a message or UI hint for the player to press the "E" button
            // You can implement this part based on your game's UI system
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hintUsed)
            {
                text.SetActive(true);

                textChange.text = "Hold E To interact";
                if (Input.GetKey(KeyCode.E))
                {
                    StartCoroutine(ActivateHint());
                }
            }
          
        }
    }

    private IEnumerator ActivateHint()
    {
        if (hintUsed)
        {
            yield break; // If the hint is already used, exit the coroutine
        }

        hintUsed = true;

        float timer = 0f;
        while (timer < activationTime)
        {
            // Player is holding down the "E" button
            timer += Time.deltaTime;

            // Display a progress indicator or feedback for the player
            // Implemt UI on later day
            yield return null;
        }
        text.SetActive(false);
        // Perform the action when the player successfully activates the hint
        // this is where FMOD implementation should be - MC talking about the specific hint
        // make a variable that can be assigned in the editor

        Debug.Log("Hint activated!");
    }



}
