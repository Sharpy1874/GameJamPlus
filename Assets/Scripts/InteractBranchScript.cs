using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBranchScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InteractTrapScript.canBeUsed = true;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
