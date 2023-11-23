using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool HasBranch;
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
}
