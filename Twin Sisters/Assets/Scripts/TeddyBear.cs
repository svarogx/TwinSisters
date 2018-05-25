using UnityEngine;
using System.Collections;

public class TeddyBear : MonoBehaviour {

	private GameObject playerControl;

	// Use this for initialization
	void Start () {
		playerControl = GameObject.FindGameObjectWithTag ("Player");
		Invoke ("Die", 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Die(){
		playerControl.GetComponent<PlayerAction> ().teddyBack ();
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D other)	{
		if (other.transform.tag == "Enemy") {
			GetComponent<Animator> ().SetTrigger ("grow");
			Destroy (other.gameObject);
		}
/*		if (other.gameObject.tag == "Player") {
			playerControl = other.gameObject; 
		}*/
	}
}
