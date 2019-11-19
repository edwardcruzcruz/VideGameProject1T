using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	float horizontalMove= 0f;
	bool jump =false;
	bool crouch = false;
	private Rigidbody2D body;
	/* 
	public Animator animator;*/
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		//animator = this.GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		horizontalMove = Input.GetAxisRaw ("Horizontal") * runSpeed;
		animator.SetFloat ("Speed",Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump")){
			jump = true;
			body.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
			animator.SetBool("IsJumping",true);
			Debug.Log("My jump velocity when I jump is: " + Input.GetButtonDown("Jump"));
			//animator.SetBool("IsJumping",true);
		}
		if (Input.GetButtonDown("Crouch")) {
			crouch = true;
		}else if (Input.GetButtonDown("Crouch")){
			crouch = false;
		}

		/*{
			//if (body.position.x > -14) {
				if(Input.GetKey(KeyCode.RightArrow)){
					var newVelocity = body.velocity;
					newVelocity.x += 1;
					body.velocity = newVelocity;
				}
			//}
		}
		{
			//if (body.position.x > -14) {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					var newVelocity = body.velocity;
					newVelocity.x -= 1;
					body.velocity = newVelocity;
				}
			//}
		}
		{
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				var newVelocity = body.velocity;
				newVelocity.y += 10;
				body.velocity = newVelocity;
			}
		}*/
	}
	public void onLanding(){
		animator.SetBool("IsJumping",false);
	}
	public void OnClimbing(bool isClimbing){
		animator.SetBool("IsClimbing",isClimbing);
	}
	void FixedUpdate(){
		controller.Move (horizontalMove*Time.fixedDeltaTime,crouch, jump);
		jump = false;
	}
}
