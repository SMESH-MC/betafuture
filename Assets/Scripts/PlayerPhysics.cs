using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	//Kollisions-Layer (Alle Objekte mit Kollision müssen auf Layer "Collision" sein)
	public LayerMask collisionMask;
	
	private BoxCollider collider;
	//Groesse des Colliders
	private Vector3 size;
	//Zentrum des Colliders
	private Vector3 center;

	private Vector3 originalSize;
	private Vector3 originalCenter;
	private float colliderScale;

	//Anzahl der Rays fuer Y-Achsen Kollision
	private int collisionDivisionX = 3;
	//Anzahl der Rays fuer X-Achsen Kollision
	private int collisionDivisionY = 10;

	//Abstand zum Boden fuer Raycast
	private float skin = .005f;

	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool moveStopped;

	//Kollisionsabfrage durch Raycast
	Ray ray;
	RaycastHit hit;

	void Start() {
		collider = GetComponent<BoxCollider>();
		colliderScale = transform.localScale.x;

		originalSize = collider.size;
		originalCenter = collider.center;
		SetCollider(originalSize, originalCenter);
	}

	//Bewege den Spieler
	public void Move(Vector2 moveAmount) {

		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 playerPosition = transform.position;

		grounded = false;

		//Raycast in Y-Richtung
		for(int i = 0; i < collisionDivisionX; i++) {
			//Richtung der Rays
			float direction = Mathf.Sign(deltaY);

			//Baut die Rays nacheinander unter/ueber dem Playerobjekt auf
			float x = (playerPosition.x + center.x - size.x/2) + size.x/(collisionDivisionX -1) * i; ;
			float y = playerPosition.y + center.y + size.y/2 * direction;
			ray = new Ray(new Vector2(x,y), new Vector2(0, direction));

			//Zeigt die Rays im Editor
			Debug.DrawRay(ray.origin, ray.direction);

			//Wenn Kollision
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask)) {
				float distance = Vector3.Distance(ray.origin, hit.point);

				if(distance > skin) {
					deltaY = distance * direction - skin * direction;
				}
				else {
					deltaY = 0;
				}
				grounded = true;
				break;
			}
		}

		moveStopped = false;

		//Raycast in X-Richtung
		for(int i = 0; i < collisionDivisionY; i++) {
			float direction = Mathf.Sign(deltaX);
			float x = playerPosition.x + center.x + size.x/2 * direction;
			float y = playerPosition.y + center.y - size.y/2 + size.y/(collisionDivisionY -1) * i;
			
			ray = new Ray(new Vector2(x,y), new Vector2(direction, 0));
			
			//Zeigt die Rays im Editor
			Debug.DrawRay(ray.origin, ray.direction);
			
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask)) {
				float distance = Vector3.Distance(ray.origin, hit.point);
				
				if(distance > skin) {
					deltaX = distance * direction - skin * direction;
				}
				else {
					deltaX = 0;
				}
				moveStopped = true;
				break;
			}
		}

		Vector3 playerDirection = new Vector3(deltaX,deltaY);
		Vector3 origin = new Vector3(playerPosition.x + center.x + size.x/2 * Mathf.Sign(deltaX),playerPosition.y + center.y + size.y/2 * Mathf.Sign(deltaY)); 

		//Raycast fuer Diagonale
		if(!moveStopped && !grounded) {
			ray = new Ray(origin, playerDirection.normalized);

			Debug.DrawRay(ray.origin, ray.direction);
			if(Physics.Raycast(ray, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY), collisionMask)) {
				grounded = true;
				deltaY = 0;
			}
		}



		Vector2 finalTransform = new Vector2(deltaX, deltaY);

		//Bewege das Playerobjekt
		transform.Translate(finalTransform);
	}
	
	public void SetCollider(Vector3 newSize, Vector3 newCenter) {
		collider.size = newSize;
		collider.center = newCenter;

		size = newSize * colliderScale;
		center = newCenter * colliderScale;
	}
}
