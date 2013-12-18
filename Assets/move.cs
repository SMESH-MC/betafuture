using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]
public class move : MonoBehaviour {
	
	public float gravity = 20;
	public float speed = 4;
	
	private PlayerPhysics playerPhysics;

	private Vector2 moveAmount;
	
	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerPhysics.grounded) {
			moveAmount.y = 0;
		}
		
		while (true) {
			moveAmount.x = speed;
			moveAmount.x = -speed;
		}

		
	}

}
