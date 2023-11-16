using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBranchScript : MonoBehaviour, IInteractable
{
    private GameObject Text;
    public void Interact()
    {
        InteractTrapScript.canBeUsed = true;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Text = FindInActiveObjectByTag("InteractText");
    }


    private void OnDestroy()
    {
        if (this.gameObject != null)
        {
            Text.SetActive(false);
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
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
