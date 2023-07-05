using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Transform player;
    private float MaxDistance = 6f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(player.position, player.forward);
            RaycastHit hit;
            if (Physics.Raycast(player.position, player.forward, out hit, MaxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
        
    }
}
