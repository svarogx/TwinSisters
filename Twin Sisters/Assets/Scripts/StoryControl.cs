using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryControl : MonoBehaviour {

	public Sprite sceneNumber1;
	public Sprite sceneNumber2;
	public Sprite sceneNumber3;
	public Sprite sceneNumber4;
	public Sprite sceneNumber5;
	public float timeScene = 2.0f;

	private int controlScene = 0;
	private Image sceneImage;

	void Start () {
		sceneImage = GetComponent<Image> ();
		CloseScene ();
	}
	
	void Update () {
	
	}

	private void CloseScene(){
		switch (controlScene) {
		case 0: 
			sceneImage.sprite = sceneNumber1;
			controlScene += 1;
			Invoke ("CloseScene", timeScene);
			break;
		case 1: 
			sceneImage.sprite = sceneNumber2;
			controlScene += 1;
			Invoke ("CloseScene", timeScene);
			break;
		case 2: 
			sceneImage.sprite = sceneNumber3;
			controlScene += 1;
			Invoke ("CloseScene", timeScene);
			break;
		case 3: 
			sceneImage.sprite = sceneNumber4;
			controlScene += 1;
			Invoke ("CloseScene", timeScene);
			break;
		case 4: 
			sceneImage.sprite = sceneNumber5;
			controlScene += 1;
			Invoke ("CloseScene", 5.0f);
			break;
		case 5:
			SceneManager.LoadScene ("Mansion");
			break;
		}
	}
}
