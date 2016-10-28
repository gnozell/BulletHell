using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float vert_velocity = 0f;
	public float hori_velocity = 0f;
	public float kill_timer = 3f;
	private Rigidbody2D objRb2D;

	// Use this for initialization
	void Start () {
		objRb2D = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		// moves the bullet at the specified speed
		objRb2D.velocity = new Vector2 (hori_velocity, vert_velocity);


		// kills bullet after the timer reaches zero
		if (kill_timer < 0) {
			Destroy (gameObject);
		}

		kill_timer -= Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
