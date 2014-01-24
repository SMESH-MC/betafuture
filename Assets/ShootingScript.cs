using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public Rigidbody projectile;
	private Rigidbody clone;
	public float speed = 20.0f;

	// Update is called once per frame
	void Update () {
		if( Input.GetButtonDown("Fire1")) {
			clone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
			clone.velocity = transform.right * speed;

			Destroy(clone.gameObject, 3);
		}
	}
}
