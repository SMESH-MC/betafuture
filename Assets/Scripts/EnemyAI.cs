using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class EnemyAI : MonoBehaviour {

	private CharacterController controller;
	private GameObject enemy;
	private Vector3 dir  = Vector3.zero;


	private GameObject player;
	public float viewField = 10.0f;
	public bool seePlayer = false;

	private health playerHealth;	
	public float damage = 10;
	public int schussrat = 30;
	private int nextSchuss = 0;
	private float oldSpeed;

	//public float debugEnemyX = 0;
	//public float debugPlayerX = 0;
	//public float debugIsInView = 0;

	public float moveDirection = 1;
	public float speed  = 6.0f;
	public float gravity = 9.81f;
	public float moveLength = 25f;
	public float distance = 5.0f;
	public bool flipped = false;

	void Awake () {
		player = GameObject.Find ("Player");
		playerHealth = player.GetComponent<health> ();
		distance = moveLength;
		controller = this.GetComponent<CharacterController>();
		enemy = this.gameObject;
	}

	void Update () {
		player = GameObject.Find ("Player");
		if (player != null) {
						seePlayer = playerIsinView ();
				} else {
						seePlayer = false;
				}
		move ();
		flipSide();
	}

	bool playerIsinView() {
			float posPlayerX = player.transform.position.x;
			float posPlayerY = player.transform.position.y;
			
			float posX = enemy.transform.position.x;
			float posY = enemy.transform.position.y;
			
			float isInView = 100;
			
			float yDiv = Mathf.Abs ( posY - posPlayerY );
			// sind auf selber Ebene
			if (yDiv <= 6.0) {
				if (!flipped) {
					if ( posX > posPlayerX ) {
						return false;
					}
					posX += viewField;
					isInView = posPlayerX - posX;
				} else {
					if ( posX < posPlayerX ) {
						return false;
					}
					posX -= viewField;
					isInView = posX - posPlayerX;
				}

			//debugEnemyX = posX;
			//debugPlayerX = posPlayerX;
			//debugIsInView = isInView;

			if ( isInView <= 0 ) {
					return true;
				}	
			}
		return false;
	}

	void shootAtPlayer() {
		if ((nextSchuss %= schussrat) == 0) { 
						ShootingEnemy shootScript = gameObject.GetComponentInChildren<ShootingEnemy> ();
						shootScript.shoot ();
				}
		++nextSchuss;
	}           




	void move() {
		if (seePlayer) {
			oldSpeed = speed;
			speed = 0.1f;
			shootAtPlayer ();
		} else {
			if (speed == 0.1f) {
				speed = oldSpeed;
			}
		}


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
