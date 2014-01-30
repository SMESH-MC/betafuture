using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {

	public Rigidbody projectile;
	private Rigidbody clone;
	public float speed = 20.0f;


	public void shoot() {
		clone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
		clone.velocity = transform.right * speed;
		
		Destroy(clone.gameObject, 3);
	}
}
