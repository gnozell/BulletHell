using UnityEngine;
using System.Collections;

public class CircleDancer : MonoBehaviour {

	public Transform player;
	public GameObject bullet;
	private Rigidbody2D DancerRb;
	private float angle = 0;
	private float radius = 5f;
	private float speed = (2f*Mathf.PI)/5f; // 5 seconds to complete circle

	private float bullettimer = 1f;

	// Use this for initialization
	void Start () {
		DancerRb = GetComponent<Rigidbody2D> ();
		bullet.GetComponent<BulletScript> ().hori_velocity = 0;
		bullet.GetComponent<BulletScript> ().vert_velocity = 0;
		bullet.GetComponent<BulletScript> ().kill_timer = 2;
		bullet.transform.position = gameObject.transform.position;
	
	}

	// Update is called once per frame
	void Update () {

		angle += speed* Time.deltaTime;

		float distance = Vector3.Distance (player.position, gameObject.transform.position);

		/*if (distance > 5f) {
			DancerRb.velocity = new Vector2 ();
		}
		if (distance < 3f) {
			DancerRb.velocity = new Vector2 ();
		}*/

		gameObject.transform.position = new Vector2 (Mathf.Cos (angle)*radius, Mathf.Sin (angle)*radius);

		if (bullettimer < 0) {
			Instantiate (bullet);
			bullettimer = 1f;
		} else {
			bullettimer -= Time.deltaTime;
		}

		//Debug.Log (distance);
	}
}
