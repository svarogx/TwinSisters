using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public void QuitButton(){
		Application.Quit();	
	}

	public void GameButton(){
		SceneManager.LoadScene ("Story");
	}
}
