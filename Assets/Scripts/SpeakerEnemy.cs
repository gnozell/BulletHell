using UnityEngine;
using System.Collections;

public class SpeakerEnemy : MonoBehaviour {

	public float time_interval = 2f;
	public float bullet_hori_vel = 0f;
	public float bullet_vert_vel = 0f;

	public float kill_timer = 3f;
	private float timer;

	public GameObject bullet;

	private float targetScale_sm = 0.9f;
	private float targetScale_lg = 1.1f;
	private float shrinkSpeed = 0.5f;
	private bool shrinking = true;

	// Use this for initialization
	void Start () {
		bullet.GetComponent<BulletScript> ().hori_velocity = bullet_hori_vel;
		bullet.GetComponent<BulletScript> ().vert_velocity = bullet_vert_vel;
		bullet.GetComponent<BulletScript> ().kill_timer = kill_timer;
		bullet.transform.position = gameObject.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shrinking) {
			gameObject.transform.localScale -= Vector3.one*Time.deltaTime*shrinkSpeed;
			if (gameObject.transform.localScale.x < targetScale_sm)
				shrinking = false;
		} else {
			gameObject.transform.localScale += Vector3.one*Time.deltaTime*shrinkSpeed;
			if (gameObject.transform.localScale.x > targetScale_lg)
				shrinking = true;
		}

		if (timer < 0) {
			Instantiate (bullet);
			timer = time_interval;
		}

		timer -= Time.deltaTime;
	}
}
