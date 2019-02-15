using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this to attach camera to player object
	public GameObject player;

	// make this private because we can set it in the script
	private Vector3 offset;

	// initialization
	void Start () {
		// subtract transform of player from transform of camera to find difference between the two
		offset = transform.position - player.transform.position;
	}
	
	// for following cameras, procedural animation, and gathering last known states, use LateUpdate().
	// LateUpdate runs every frame like Update but is garunteed to run after all items have been processed in Update.
	// Using this, we know that the player has already moved for this frame.
	void LateUpdate () {
		// as we move the player object the camera's position is updated based on the player's position.
		// This is processed before displaying what the camera can "see"
		transform.position = player.transform.position + offset;
	}
}