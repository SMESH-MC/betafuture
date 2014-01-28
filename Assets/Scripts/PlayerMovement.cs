using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour {

	private CharacterController controller;
	private GameObject enemy;
	private Vector3 dir  = Vector3.zero;


	public int moveWidth = 5;

	public float speed  = 6.0f;
	public float gravity = 9.81f;
	public float jumpPower = 5.0f;
	public bool flipped = false;

	void Awake () {
		controller = this.GetComponent<CharacterController>();
		enemy = this.gameObject;
	}

	void Update () {
		move ();
		flipSide();
	}

	void move() {
		if(controller.isGrounded){
			dir.x = Input.GetAxis("Horizontal") * speed;
		}
		else {
			dir.y = dir.y - gravity;
			dir.x = (Input.GetAxis("Horizontal") * speed );
		}

		if(dir.x > 0){
			flipped = false;
		} else if (dir.x < 0) {
			flipped = true;
		} 
		controller.Move(dir * Time.deltaTime);
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
