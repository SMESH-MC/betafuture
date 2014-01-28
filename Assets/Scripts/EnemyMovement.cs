using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class EnemyMovement : MonoBehaviour {

	private CharacterController controller;
	private GameObject enemy;
	private Vector3 dir  = Vector3.zero;

	public float moveDirection = 1;
	public float speed  = 6.0f;
	public float gravity = 9.81f;
	public float moveLength = 25f;
	public float distance = 5.0f;
	public bool flipped = false;

	void Awake () {
		distance = moveLength;
		controller = this.GetComponent<CharacterController>();
		enemy = this.gameObject;
	}

	void Update () {
		move ();
		flipSide();
	}

	void move() {
		float dirXOld = transform.position.x;

		if(controller.isGrounded){
			dir.x = moveDirection * speed;
		}
		else {
			dir.y = dir.y - gravity;
			dir.x = moveDirection * speed;
		}

		if(dir.x > 0){
			flipped = false;
		} else if (dir.x < 0) {
			flipped = true;
		} 

		controller.Move(dir * Time.deltaTime);

		distance = distance - ((dirXOld - transform.position.x) * moveDirection);

		if (distance <= 0) {
			distance = moveLength;
			moveDirection *= -1;
		}
	}

	void flipSide() {
		if (flipped){
			enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		else{
			enemy.transform.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}
}
