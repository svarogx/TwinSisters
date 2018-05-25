using UnityEngine;
using System.Collections;

public class PaintScript : MonoBehaviour {

	public float speed = 10f;
	public float limit = 10f;
	public AudioClip laughtAudio;
	public AudioClip dropAudio;
	public SpiderNest nest1;
	public SpiderNest nest2;

	private AudioSource frameSound;
	private int phase = 0;
	private int angle = 0;

	private bool paintTrigger = false;
	private bool spiderTrigger = false;
	// Use this for initialization
	void Start () {
		frameSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (paintTrigger && phase < 3) {
			if (phase == 1) {
				angle += 1;
				this.transform.eulerAngles = new Vector3 (0, 0, angle);
				if (angle > 15)
					phase = 2;
			} else if (phase == 2) {
				angle -= 1;
				this.transform.eulerAngles = new Vector3 (0, 0, angle);
				if (angle < 0)
					phase = 3;
			}
		}
		if (paintTrigger && phase == 3 && this.transform.position.y >= limit)
			this.transform.Translate (0f, -speed * Time.deltaTime, 0f);
		if (phase == 4) {
			frameSound.Stop ();
			frameSound.clip = dropAudio;
			frameSound.loop = false;
			frameSound.Play ();
			phase = 5;
		}
	}

	private void OnTriggerEnter2D(Collider2D hit){
		if (hit.tag == "Floor" && phase == 3)
			phase = 4;
		if (hit.tag != "Player" || phase > 0)
			return;
		if (paintTrigger == false) {
			frameSound.Stop ();
			frameSound.clip = laughtAudio;
			frameSound.loop = false;
			frameSound.Play ();
		}
		paintTrigger = true;
		phase = 1;

		if (hit.tag == "Player" && !spiderTrigger) {
			if (nest1 != null)
				nest1.SpiderStart ();
			if (nest2 != null)
				nest2.SpiderStart ();
			spiderTrigger = true;
		}
	}

}
