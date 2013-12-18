using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]
public class EnemyMove : MonoBehaviour {
	
	public float gravity = 20;
	public float speed = 6;
	public float acceleration = 10;
	public float jumpHeight = 0;
	
	private int i;
	private int bewegungsweite = 3;
	private bool left = true;
	//Instanzierung des PlayerPhysics-Script
	private PlayerPhysics playerPhysics;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 moveAmount;
	
	// Use this for initialization
	void Start () {
		i = 0;
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Wenn Kollision auf der X-Achse, setze Geschwindigkeit auf 0
		if(playerPhysics.moveStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		//Eingabeabfrage
		if (i == -bewegungsweite) {
			left = false;
		}
		if (i == 0) {
			left = true;
		}
		if (left) {
			targetSpeed = -speed;
			i--;
		}else {
			targetSpeed = speed;
			i++;
		}
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
		
		//Wenn Player auf Boden, setze Bewegung in Y-Richtung auf 0;
		if (playerPhysics.grounded) {
			moveAmount.y = 0;
			
			
		}
		
		moveAmount.x = currentSpeed;
		
		//Schwerkraft beeinflusst Y-Bewegung
		moveAmount.y -= gravity * Time.deltaTime;
		//Gib die Bewegung an Kollisionsabfrage weiter
		playerPhysics.Move(moveAmount * Time.deltaTime);
		
	}
	
	//Schrittweises erhoehen der Geschwindigkeit (Beschleunigung)
	private float IncrementTowards(float cSpeed, float target, float accel) {
		if ( cSpeed == target) {
			return cSpeed;
		}
		else {
			float direction = Mathf.Sign(target - cSpeed); //Mathf.Sign(float x) 1 wenn x >= 0, -1 wenn x < 0
			cSpeed += accel * Time.deltaTime * direction;
			//Wenn 
			return (direction == Mathf.Sign(target - cSpeed))? cSpeed : target; //Wenn sich die Richtung nicht aendert gib cSpeed zurueck, ansonsten target; 
		}
	}
}
