using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerTurn : MonoBehaviour
{
    
    public Vector2 turn;
    public player player;
    public PauseToggle pauseToggle;

    
    void Update()
    {
        if (player.isDead == false && pauseToggle.isPaused == false){
        
         turn.x = Input.GetAxis("Mouse X");
         transform.Rotate(0, turn.x, 0);  
        } 
    }
}
