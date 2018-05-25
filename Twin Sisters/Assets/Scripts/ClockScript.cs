using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour {

	public AudioClip tickTock;
	public AudioClip chimes;

	private AudioSource clockSound;
	private bool triggerSound = true;

	void Start () {
		clockSound = GetComponent<AudioSource> ();
		clockSound.clip = tickTock;
		clockSound.loop = true;
		clockSound.Play ();
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if (hit.tag == "Player" && triggerSound) {
			clockSound.Stop ();
			clockSound.clip = chimes;
			clockSound.loop = false;
			clockSound.Play ();
			triggerSound = false;
		}
	}

}
