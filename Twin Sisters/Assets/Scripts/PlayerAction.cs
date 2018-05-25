using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 5f;
	public KeyCode attackButton;
	public GameObject teddyBear;

	private Rigidbody2D playerBody;
	private Animator playerAnimator;
	private float move;
	private bool facingRight = true;
	private bool grounded;
	private bool isAttacking = false;

	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
	}
	
	void Update () {
		if (!isAttacking) {
			move = Input.GetAxis ("Horizontal") * speed;
			if (move != 0) {
				if (move < 0)
					moveLeft ();
				else
					moveRight ();
			}
			if (Input.GetButtonDown ("Jump"))
				actionJump ();
			playerAnimator.SetFloat ("speed", Mathf.Abs (move));
			if ((Input.GetKeyDown (attackButton)) && grounded && move < 0.1f) 
				actionAttack ();
		}
	}

	public void moveLeft(){
		if (facingRight)
			Flip ();
		playerBody.velocity = new Vector2(move, playerBody.velocity.y);
	}

	public void moveRight(){
		if (!facingRight)
			Flip ();
		playerBody.velocity = new Vector2(move , playerBody.velocity.y);
	}

	public void actionJump(){
		if(grounded == true){		
			playerBody.velocity = new Vector2(playerBody.velocity.x,jumpForce);
			grounded = false;
			playerAnimator.SetBool ("ground",grounded);
			playerAnimator.SetTrigger("jump");
		}
	}

	public void actionAttack(){
		isAttacking = true;
		playerAnimator.SetBool ("attack", isAttacking);
		float bearoff, orient;
		if (facingRight){
			bearoff = 0.2f;
			orient = 5.0f;
		}else{
			bearoff = -0.2f;
			orient = -5.0f;
		}
		Vector3 bearpos = new Vector3(transform.position.x + bearoff, transform.position.y + 0.2f, transform.position.z);
		GameObject bear = Instantiate (teddyBear, bearpos, Quaternion.identity) as GameObject;
		if (facingRight)
			bear.transform.eulerAngles = new Vector3(0, 0, 0);
		else
			bear.transform.eulerAngles = new Vector3(0, 180, 0);
		bear.GetComponent<Rigidbody2D>().AddForce(new Vector2(orient,10f));

	}

	public void teddyBack(){
		isAttacking = false;
		playerAnimator.SetBool ("attack", isAttacking);
	}

	private void Flip (){
		facingRight = !facingRight;
		if (facingRight)
			this.transform.eulerAngles = new Vector3 (0, 0, 0);
		else
			this.transform.eulerAngles = new Vector3 (0, 180, 0);
	}

	private void OnCollisionEnter2D(Collision2D hit){
		if (hit.collider.tag == "Floor") {
			grounded = true;
			playerAnimator.SetBool ("ground",grounded);
		}
	}

	public void Die(){
		playerAnimator.SetTrigger ("dead");
		SceneManager.LoadScene ("Mansion");
	}

	private void OnCollisionStay2D(Collision2D hit){
		if (hit.collider.tag == "Floor") {
			if (hit.relativeVelocity.magnitude < 0.1f)
			grounded = true;
			playerAnimator.SetBool ("ground",grounded);
		}
	}
}
