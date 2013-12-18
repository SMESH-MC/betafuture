using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	public float speed = 5;
	private Vector2 move;
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		walk ();
	}
	
	void walk() {
		if (i >= 0 & i < 10) {
			move.x = -speed;
			i++;
		} else {
			move.x = speed;
			i--;
		}
	}
	
}