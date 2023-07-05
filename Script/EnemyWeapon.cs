using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public BoxCollider weaponCollider;
    public Animator animator;
    //animation time
    private string animationStateName = "Attack01";
    private float animationTime = 0.25f;
    public EnemyHandler enemyHandler;


    public void Update(){

       if (enemyHandler.isAttacking == true)
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
        weaponCollider.enabled = true;
    }

    public void DisableSwordCollider()
    {
        weaponCollider.enabled = false;
    }
}
