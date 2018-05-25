using UnityEngine;
using System.Collections;

public class SpiderNest : MonoBehaviour {

	public GameObject spiderPrefab;
	public int spiderNumber = 50;
	public float spawnTime = 0.5f;

	private int spiderCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpiderStart(){
		if (spiderPrefab == null)
			return;
		spiderCount = spiderNumber;
		Invoke ("SpiderSpawn", spawnTime);
	}

	private void SpiderSpawn(){
		if (spiderPrefab == null)
			return;
		if (spiderCount <= 0)
			return;
		Instantiate (spiderPrefab, transform.position, Quaternion.identity);
		Invoke ("SpiderSpawn", spawnTime);
		spiderCount--;
	}
}
