using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, j_force;
	public bool walking;
	public Transform playerTrans;
	public bool isGrounded;
	public BoxCollider playerCollider;
	public health healthStat;
	public int maxValue = 100;
	public int currentHealth = 100;
	public bool isDefending = false;
	public bool isDead = false;

	
	
	void Update(){

		if(Input.GetKey(KeyCode.W) && isGrounded && walking == true && isDead == false){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
			
			
		}
		
		if(Input.GetKey(KeyCode.S) && isGrounded && walking == true && isDead == false){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.A) && isGrounded && walking == true && isDead == false){
			// playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
			playerRigid.velocity = -transform.right * wb_speed * Time.deltaTime;

			
		}
		if(Input.GetKey(KeyCode.D) && isGrounded && walking == true && isDead == false){
			// playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
			playerRigid.velocity = transform.right * wb_speed * Time.deltaTime;
		}

		

		if(Input.GetKeyDown(KeyCode.W) && isDead == false){
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			walking = true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.W) && isDead == false){
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			walking = false;
			//steps1.SetActive(false);
		}

		if(Input.GetKeyDown(KeyCode.S) && isDead == false){
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			//steps1.SetActive(true);
			walking = true; 
		}
		if(Input.GetKeyUp(KeyCode.S) && isDead == false){
			playerAnim.ResetTrigger("strafe");
			playerAnim.SetTrigger("idle");
			//steps1.SetActive(false);
			walking = false;
			
		}

		if(Input.GetKeyDown(KeyCode.A) && isDead == false){
			playerAnim.SetTrigger("strafe");
			playerAnim.ResetTrigger("idle");
			//steps1.SetActive(true);
			walking = true;
		}

		if(Input.GetKeyUp(KeyCode.A) && isDead == false){
			playerAnim.ResetTrigger("strafe");
			playerAnim.SetTrigger("idle");
			//steps1.SetActive(false);
			walking = false;
			
		}

		if(Input.GetKeyDown(KeyCode.D) && isDead == false){
			playerAnim.SetTrigger("strafe");
			playerAnim.ResetTrigger("idle");
			//steps1.SetActive(true);
			walking = true;
		}

		if(Input.GetKeyUp(KeyCode.D) && isDead == false){
			playerAnim.ResetTrigger("strafe");
			playerAnim.SetTrigger("idle");
			//steps1.SetActive(false);
			walking = false;
			
		}
		
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				//steps1.SetActive(false);
				//steps2.SetActive(true);
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("sprint");
				playerAnim.ResetTrigger("walk");
				walking = true;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				//steps1.SetActive(true);
				//steps2.SetActive(false);
				w_speed = olw_speed;
				playerAnim.ResetTrigger("sprint");
				playerAnim.SetTrigger("walk");
				
			}
            if(Input.GetKeyDown(KeyCode.G)){
                playerAnim.SetTrigger("walk");
                playerAnim.ResetTrigger("idle");
				DisableHitBox();
				isDefending = true;
				
            }
			if (Input.GetKeyUp(KeyCode.G)||Input.GetKeyUp(KeyCode.LeftShift)){
				playerAnim.ResetTrigger("sprint");
				playerAnim.SetTrigger("idle");
				EnableHitBox();
				isDefending = false;
			}
			if(Input.GetKeyUp(KeyCode.G)){
				playerAnim.ResetTrigger("defend");
				playerAnim.SetTrigger("idle");
				EnableHitBox();
				isDefending = false;
			}
		}
			if(Input.GetKeyDown(KeyCode.G)){
                playerAnim.SetTrigger("defend");
                playerAnim.ResetTrigger("idle");
				DisableHitBox();
				isDefending = true;

            }
			if(Input.GetKeyUp(KeyCode.G) && isDead == false){
				playerAnim.ResetTrigger("defend");
				playerAnim.SetTrigger("idle");
				EnableHitBox();
				isDefending = false;
			}

			// attack if mouse left click is pressed
			if(Input.GetMouseButtonDown(0) && isDead == false){
				playerAnim.SetTrigger("attack1");
				playerAnim.ResetTrigger("idle");
				walking = false;
			}
			if(Input.GetMouseButtonUp(0) && isDead == false){
				playerAnim.ResetTrigger("attack1");
				playerAnim.SetTrigger("idle");
			}

			if(Input.GetMouseButtonDown(1) && isDead == false){
				playerAnim.SetTrigger("attack2");
				playerAnim.ResetTrigger("idle");
				walking = false;
			}
			if(Input.GetMouseButtonUp(1) && isDead == false){
				playerAnim.ResetTrigger("attack2");
				playerAnim.SetTrigger("idle");
				
			}

			if(Input.GetKeyDown(KeyCode.Space)&& isGrounded == true && isDead == false){
			playerRigid.AddForce(Vector3.up * j_force, ForceMode.Impulse);
			isGrounded = false;
			playerAnim.SetTrigger("jump");
			playerAnim.ResetTrigger("idle");
		}
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			playerAnim.ResetTrigger("jump");
			playerAnim.SetTrigger("idle");
		}
		
        if (w_speed > 3000){
			w_speed = 3000;
		}

		if (currentHealth <= 0){
			playerAnim.SetTrigger("death");
			playerAnim.ResetTrigger("idle");
			walking = false;
			isDead = true;
			Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene("LOSS SCREEN");
		}
		
	}

	    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthStat.SetHealth(currentHealth);
    }

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Ground"){
			isGrounded = true;
		} 
	}
	 
	void OnCollisionStay(Collision collision) {
    if(collision.gameObject.tag == "Ground") {
            isGrounded = true;
     }
    }
	void OnCollisionExit(Collision collision) {
    if(collision.gameObject.tag == "Ground") {
         isGrounded = false;
     }
    }

	void EnableHitBox(){
		playerCollider.enabled = true;
	}

	void DisableHitBox(){
		playerCollider.enabled = false;
	}

	void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("enemy-weapon") && isDefending == false)
        {
			TakeDamage(10);
        }
        
        
        
    }

	

	

	

}



