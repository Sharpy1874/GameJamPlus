using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KliesteScript : MonoBehaviour, IInteractable
{
    private GameObject Text;

    public void Interact()
    {
        if (this.gameObject != null)
        {
            Text.SetActive(false);
        }
        else
        {
            return;
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Text = FindInActiveObjectByTag("InteractText");
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
            Debug.Log(PlayerCheckScript.HasKlieste);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerCheckScript.HasKlieste == false)
                {
                    PlayerCheckScript.HasKlieste = true;
                    Interact();
                }
                else
                {
                    return;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(false);
        }
    }

    GameObject FindInActiveObjectByTag(string tag)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}