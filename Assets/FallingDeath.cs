using UnityEngine;
using System.Collections;

public class FallingDeath : MonoBehaviour {

	public float deadline;
	private GameObject player;
	private float playerY;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		playerY = player.transform.position.y;
		if(playerY < deadline) {
			Object.Destroy(player);
		}
	}
}
