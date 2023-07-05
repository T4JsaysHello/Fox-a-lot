using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHandler : MonoBehaviour
{
    public bool willHit = false;
    public int maxValue = 100;
    public int currentValue = 100;
    public HealthStat healthStat;
    public Animator enemyAnim;
    public bool isAttacking = false;
    public bool isAlive = true;
    public int random;
    void Start()
    {
        currentValue = maxValue;
        healthStat.SetMaxHealth(maxValue);
        StartCoroutine(AttackPattern());
    }

    void Update()
    {
        
        Die();
        if (willHit == true && isAlive == true)
        {
            AttackStatus();
            isAttacking = true;
        } else
        {
            Idle();
            isAttacking = false;
        }

        if (isAlive == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("WIN SCREEN");
            
            
        }

    }

    void TakeDamage(int damage)
    {
        currentValue -= damage;
        healthStat.SetHealth(currentValue);
    }

    
    IEnumerator AttackPattern()
    {
        while(isAlive == true)
        {
            int random = Random.Range(0, 4);
            yield return new WaitForSeconds(3);
            Debug.Log(random);
            if (random == 0 || random == 1)
            {
                willHit = true;
            }
            else
            {
                willHit = false;
            }
        }
    }

    void Die()
    {   
        if (currentValue <= 0)
        {
            isAlive = false;
            enemyAnim.SetTrigger("Die");
            Destroy(gameObject, 5f);
            
            
        }
        
    }

    void Idle()
    {
        enemyAnim.SetTrigger("Idle");
    }
   
    void AttackStatus()
    {
            isAttacking = true;
            enemyAnim.SetTrigger("Attack01");
    }


    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("weapon"))
        {
            enemyAnim.SetTrigger("GetHit");
            TakeDamage(3);
        }   
        
    }
    
    

    

    
}
