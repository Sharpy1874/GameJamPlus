using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCheckScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool HasBranch;
    public static bool HasKlieste;
    [SerializeField] GameObject PlayerBranch;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inGamePanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasBranch == true)
        {
            PlayerBranch.SetActive(true); 
        }
        else
        {
            PlayerBranch.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            inGamePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void Resume()
    {
        inGamePanel.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WireTrap") && HasKlieste)
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
