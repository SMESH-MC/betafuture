using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class EnemyMovement : MonoBehaviour {

	private CharacterController controller;
	private GameObject player;
	private Vector3 dir  = Vector3.zero;


	public float speed  = 6.0f;
	public float gravity = 9.81f;
	public float distance = 5.0f;
	public bool flipped = false;

	void Awake () {
		controller = this.GetComponent<CharacterController>();
		player = this.gameObject;
	}

	void Update () {
		move ();
		flipSide();
	}

	void move() {
		float dirXOld = dir.x;

		if(controller.isGrounded){
			dir.x = distance * speed;
		}
		else {
			dir.y = dir.y - gravity;
			dir.x = distance * speed;
		}

		if(dir.x > 0){
			flipped = false;
		} else if (dir.x < 0) {
			flipped = true;
		} 
		distance -= (dirXOld - dir.x);
		controller.Move(dir * Time.deltaTime);
	}

	void flipSide() {
		if (flipped){
			player.transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		else{
			player.transform.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}
}
