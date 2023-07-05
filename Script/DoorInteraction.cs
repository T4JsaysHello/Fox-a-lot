using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public string sceneName;
    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
