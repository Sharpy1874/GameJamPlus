using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrapScript : MonoBehaviour, IInteractable
{
    public bool wasUsed = false;
    public bool canBeUsed = false;
    [SerializeField] private GameObject Text;
    [SerializeField] private Outline outline;
    [SerializeField] private GameObject notUsed;
    [SerializeField] private GameObject used;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Outline>();
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
}
