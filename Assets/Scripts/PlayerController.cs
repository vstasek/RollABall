//Check every frame for input and apply that input to the Player game object as movement

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Ctrl + '

//Update() is called before rendering a frame
//FixedUpdate() is called before performing any physics calculations


public class PlayerController : MonoBehaviour 
{

	public float speed;
	public Text countText;
	public Text winText;

	/*Rigidbody objects allow control of an object's position through physics simulation.
	 * 
	Adding a Rigidbody component to an object will put its motion under the control of 
	Unity's physics engine. Even without adding any code, a Rigidbody object will be pulled 
	downward by gravity and will react to collisions with incoming objects if the right 
	Collider component is also present. */
	private Rigidbody rb;

	private int count;

	// Start() gets called on the first frame that the script is active (usually first frame of game)
	void Start ()
	{
		count = 0;
		SetCountText ();
		winText.text = "";

		// get access to actual RigidBody component of our Player object
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
		// Stores player input read from the keyboard
		// Automatically uses arrow keys. How do I use different keys?...
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a vector out of the player input data to apply to RigidBody
			// y is 0 because we don't want to move up
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	// This will be called when Player first touches a trigger collider.
	// 'other' is a reference to the Collider we have touched
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			count++;
			SetCountText ();
			other.gameObject.SetActive (false);
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 16) 
		{
			winText.text = "CONGRATULATIONS!\nYOU WIN FOREVER!";
		}
	}
}