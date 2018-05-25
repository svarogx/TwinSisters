using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

	public AudioClip[] stepSound;
	public AudioClip jumpSound;

	private AudioSource audioPlayer;
	private int last = -1;

	// Use this for initialization
	void Start () {
		audioPlayer = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayStep(){
		int tmp = 0;
		do{
			tmp = (int)Random.Range (0.0f, 8.0f);
		} while (last == tmp);
		last = tmp;
		audioPlayer.Stop ();
		audioPlayer.clip = stepSound[last];
		audioPlayer.loop = false;
		audioPlayer.Play ();
	}

	public void PlayJump(){
		//		if (audioPlayer.clip == stepSound && audioPlayer.isPlaying)
		//			return;
		audioPlayer.Stop ();
		audioPlayer.clip = jumpSound;
		audioPlayer.loop = false;
		audioPlayer.Play ();
	}

}
