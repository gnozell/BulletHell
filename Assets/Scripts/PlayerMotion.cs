using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody2D playerRb2D;

	// Use this for initialization
	void Start () {
		playerRb2D = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		float direction_x = 1f;
		float direction_y = 1f;
		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		// direction to move the player
		if (hor < 0) {
			direction_x *= -1;
		}
		if (vert < 0) {
			direction_y *= -1;
		}

		// adds force to the player if the button is being pressed
		if (Input.GetButton("Horizontal")) {
			playerRb2D.velocity = new Vector2 (speed*direction_x, playerRb2D.velocity.y);
		}
		if (Input.GetButton("Vertical")) {
			playerRb2D.velocity = new Vector2 (playerRb2D.velocity.x, speed*direction_y);
		}

		// once the button is released it no longer moves that direction
		if (Input.GetButtonUp ("Horizontal")) {
			playerRb2D.velocity = new Vector2 (0, playerRb2D.velocity.y);
		}

		if (Input.GetButtonUp ("Vertical")) {
			playerRb2D.velocity = new Vector2 (playerRb2D.velocity.x, 0);
		}

	}
}
