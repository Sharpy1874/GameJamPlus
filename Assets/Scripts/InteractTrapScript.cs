using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrapScript : MonoBehaviour, IInteractable
{
    private bool wasUsed = false;
    public static bool canBeUsed = false;
    private GameObject Text;
    [SerializeField] private Outline outline;
    [SerializeField] private GameObject notUsed;
    [SerializeField] private GameObject used;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Outline>();
        Text = FindInActiveObjectByTag("InteractText");
        used.SetActive(false);
        notUsed.SetActive(true);
        Text.SetActive(false);
        outline.OutlineWidth = 0f;
    }
    
// Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
            outline.OutlineWidth = 10f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(false);
            outline.OutlineWidth = 0f;
        }
    }

    public void Interact()
    {
        if (canBeUsed)
        {
            if (!wasUsed)
            {
                wasUsed = true;
                canBeUsed = false;
                used.SetActive(true);
                notUsed.SetActive(false);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
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
