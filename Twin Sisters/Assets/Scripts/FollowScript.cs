using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
	public Transform target;
	public float smoothing = 5f;
	public float minY = -3.4f;
	public float maxY = 5.4f;
	public float minX = -31.8f;
	public float maxX = 31.8f;
	public float xOffset;
	public float yOffset;
	public float zOffset;

	void FixedUpdate () {
		Vector3 offset = new Vector3 (xOffset, yOffset, zOffset);
		Vector3 pos = Vector3.Lerp (transform.position, target.position + offset, Time.deltaTime * smoothing);
		pos.x = Mathf.Clamp(pos.x, minX, maxX);
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
}
