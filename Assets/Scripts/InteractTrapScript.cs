using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrapScript : MonoBehaviour, IInteractable
{
    private bool wasUsed = false;
    public static bool canBeUsed = false;
    private GameObject Text;
    [SerializeField] private GameObject openTrap;
    [SerializeField] private GameObject closedTrap;
    // Start is called before the first frame update
    void Start()
    {
        Timer TrapDis = GetComponent<Timer>();
        gameObject.GetComponent<Outline>();
        Text = FindInActiveObjectByTag("InteractText");
        closedTrap.SetActive(false);
        openTrap.SetActive(true);
        Text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
            Text.SetActive(false);
    }

    public void Interact()
    {
        if (canBeUsed)
        {
            if (!wasUsed)
            {
                // If trap is open, close it
                openTrap.SetActive(false);
                closedTrap.SetActive(true);
                wasUsed = true;
                StartCoroutine(TimeToDespawn(3f));
                Debug.Log("Trap closed!");
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

    private IEnumerator TimeToDespawn(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
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
