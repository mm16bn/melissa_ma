using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 5f;
	public float jumpheight = 2f;
	Rigidbody2D rb;
	Animator animator;
	SpriteRenderer sr;
	BoxCollider2D my_collider;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();			
		my_collider = GetComponent<BoxCollider2D>();
	}

	void Update(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position += new Vector3(moveHorizontal,0f,0f) * Time.deltaTime * playerSpeed;

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){//Jumping
			rb.velocity = new Vector2(0f, jumpheight);
			//transition to jumping
			changeState("isJumping");
		}
		else if(moveHorizontal < 0){
			//transition to walking
			sr.flipX = true;
			changeState("isWalking");
		}
		else if(moveHorizontal > 0){
			//transition to walking
			sr.flipX = false;
			changeState("isWalking");
		}
		else{
			//transition to idle
			changeState("isIdle");
		}
		print(isGrounded());
	}


	private bool isGrounded(){
		//print((transform.position - new Vector3(0f, my_collider.bounds.extents.y -1)));
		Collider2D other = Physics2D.OverlapBox( (transform.position - new Vector3(0f, my_collider.bounds.extents.y + .5f )), new Vector2(1f,.02f), 0f );
		//print("Collider2d=" + other.gameObject.name);
		if(other){	//if other collider exists
			if(other.CompareTag("floor")){ //check the tag to see if it's the floor
				return true;
			}
		}
		return false;
	}

	void changeState(string state){
		animator.SetTrigger(state);
	}
}
