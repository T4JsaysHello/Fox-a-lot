using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInteraction : MonoBehaviour, IInteractable 
{
    public void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    }
}
