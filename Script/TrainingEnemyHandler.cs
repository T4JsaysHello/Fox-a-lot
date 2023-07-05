using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEnemyHandler : MonoBehaviour
{
    public int maxValue = 100;
    public int currentValue = 100;
    public HealthStat healthStat;
    public Animator enemyAnim;
    public bool isAlive = true;

    void Start()
    {
        currentValue = maxValue;
        healthStat.SetMaxHealth(maxValue);
        
    }

    void Update()
    {
        
        Die();
       

    }

    void TakeDamage(int damage)
    {
        currentValue -= damage;
        healthStat.SetHealth(currentValue);
    }

    
    

    void Die()
    {   
        if (currentValue <= 0)
        {
            isAlive = false;
            enemyAnim.SetTrigger("Death");
            Revive();
        }
        
    }

    void Revive()
    {
        if (isAlive == false)
        {
            currentValue = maxValue;
            healthStat.SetHealth(currentValue);
            isAlive = true;
            enemyAnim.SetTrigger("Recover");
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("weapon"))
        {
            enemyAnim.SetTrigger("Hit");
            TakeDamage(3);
        }   
        
    }
    
    

    

    
}

