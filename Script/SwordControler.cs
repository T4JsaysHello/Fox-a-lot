using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControler : MonoBehaviour
{
    public BoxCollider swordCollider;
    public Animator animator;
    //animation time
    private string animationStateName = "Attack01";
    private float animationTime = 0.25f;


    public void Update(){

       if (IsAnimationPlaying(animationStateName))
        {
            EnableSwordCollider();
           
        }
        else
        {
            DisableSwordCollider();
            
        }
        
    }

    public bool IsAnimationPlaying(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f;
    }

    public void EnableSwordCollider()
    {
        swordCollider.enabled = true;
    }

    public void DisableSwordCollider()
    {
        swordCollider.enabled = false;
    }
}
