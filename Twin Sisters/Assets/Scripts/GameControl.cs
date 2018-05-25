using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] gamePlayers = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject gamePlayer in gamePlayers) {
//			Debug.Log (gamePlayer.name);
//			Debug.Log (gamePlayer.transform.position);
			if (gamePlayer.name == "Player(Clone)")
				Destroy (gamePlayer);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag != "Player") 
			return;
		SceneManager.LoadScene ("Menu");
	}

}
