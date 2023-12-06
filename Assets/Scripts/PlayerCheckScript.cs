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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WireTrap") && HasKlieste)
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
