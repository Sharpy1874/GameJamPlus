using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpenerScript : MonoBehaviour
{
    bool isOpened;
   [SerializeField] GameObject fullMap;
    // Start is called before the first frame update
    void Start()
    {
        fullMap.SetActive(false);
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isOpened)
            {
                isOpened = false;
            }
            else
            {
                isOpened = true;
            }
        }
    }
    private void FixedUpdate()
    {
        MapOpener();
    }
    private void MapOpener()
    {
        if (isOpened)
        {
            fullMap.SetActive(true);
        }
        else
        {
            fullMap.SetActive(false);
        }
    }
}
