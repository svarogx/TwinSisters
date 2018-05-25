using UnityEngine;
using System.Collections;

public class CareTaker : MonoBehaviour {

	public Vector3 controlPoint1;
	public Vector3 controlPoint2;
	public float speed = 0.3f;
	public AudioClip walkSoud;

	private Vector3 target;
	private Vector3 origin;
	private float time;
	private AudioSource careTakerAudio;

	// Use this for initialization
	void Start () {
		careTakerAudio = GetComponent<AudioSource> ();
		careTakerAudio.Stop ();
		careTakerAudio.loop = true;
		careTakerAudio.clip = walkSoud;
		careTakerAudio.Play ();
		PreparePath ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.position = Vector3.Lerp (origin, target, time * speed);
		if ((transform.position - target).magnitude <= .01f)
			Flip();

	}

	void PreparePath() {
		if(transform.localScale.x > 0f) {
			transform.position = controlPoint1;
			target = controlPoint2;
		} else {
			transform.position = controlPoint2;
			target = controlPoint1;
		}
		origin = transform.position;
		time = 0f;
	}

	void Flip () {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		PreparePath ();
	}

	private void OnCollisionEnter2D(Collision2D hit){
		if (hit.collider.tag == "Player") {
//			hit.transform.gameObject.GetComponent<PlayerAction> ().Die ();
			hit.gameObject.GetComponent<PlayerAction> ().Die ();
			Debug.Log (this.gameObject.name);
		}
	}

}
