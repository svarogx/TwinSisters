using UnityEngine;
using System.Collections;

public class SpiderControl : MonoBehaviour {

	public float speed = 5.0f;
	public float jump = 2.0f;
	public AudioClip walk;
	public AudioClip chill;

	private Transform gamePlayer;
	private Rigidbody2D spiderBody;
	private bool isJumping = false;
	private float newSpeed;
	private float newJump;

	private AudioSource spiderAudio;
	// Use this for initialization
	void Start () {
		gamePlayer = GameObject.FindGameObjectWithTag ("Player").transform;
		spiderBody = GetComponent<Rigidbody2D> ();	
		spiderAudio = GetComponent<AudioSource> ();
		Invoke ("SpiderJump", 2.0f);
		newSpeed = Random.Range (speed/2, speed);
		newJump = Random.Range (jump/2, jump);
		spiderAudio.Stop ();
		spiderAudio.loop = true;
		spiderAudio.clip = walk;
		spiderAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gamePlayer == null)
			return;
		if (transform.position.x > gamePlayer.position.x) {
			transform.eulerAngles = new Vector3 (0, 180, 0);
			spiderBody.velocity = new Vector2(-newSpeed, spiderBody.velocity.y);
		} else {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			spiderBody.velocity = new Vector2(newSpeed, spiderBody.velocity.y);
		}	
		if (!spiderAudio.isPlaying) {
			spiderAudio.Stop ();
			spiderAudio.loop = true;
			spiderAudio.clip = walk;
			spiderAudio.Play ();
		}
	}

	private void SpiderJump(){
		if (!isJumping) {
			spiderBody.velocity = new Vector2 (spiderBody.velocity.x, newJump);
			isJumping = true;
			spiderAudio.Stop ();
			spiderAudio.loop = false;
			spiderAudio.clip = chill;
			spiderAudio.Play ();
		}
		Invoke ("SpiderJump", Random.Range (0.1f, 5.0f));
	}

	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.tag == "Floor") 
			isJumping = false;
		
	}
}
