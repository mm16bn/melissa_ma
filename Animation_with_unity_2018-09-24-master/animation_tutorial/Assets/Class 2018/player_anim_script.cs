using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_anim_script : MonoBehaviour {
	public float speed = 10;
	public float jump_speed = 5;
	public Rigidbody2D rb;
	Animator my_animator;
	bool is_grounded = true;

	// Use this for initialization
	void Start () {
		my_animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		transform.position += x * speed * Time.deltaTime * (new Vector3(1f,0f,0f));

		if (Input.GetKey(KeyCode.Space) && is_grounded) {
			my_animator.SetTrigger("isJumping");
			is_grounded = false;
			//rb.AddForce(new Vector2(0f, 20f));
			rb.velocity = new Vector2(0f, jump_speed); // Alternative to AddForce
		} else if (x > 0) {
			my_animator.SetTrigger("isWalking");
			transform.localScale = new Vector3(1f,1f,1f);
		} else if (x < 0) {
			my_animator.SetTrigger("isWalking");
			transform.localScale = new Vector3(-1f,1f,1f);
		} else {
			my_animator.SetTrigger("isIdle");
		}
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Ground")) {
			is_grounded = true;
			print("ground");
		}
	}
}



