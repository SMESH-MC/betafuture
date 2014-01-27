using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public Transform Door;

	bool isOpen = false;
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider player) {
		if(player.tag == "Player") {
			Debug.Log(player.tag);
		
			Door.animation.CrossFade("DoorOpen");

		}
	}

	void OnTriggerExit(Collider player) {
		if(player.tag == "Player"){
		
			Door.animation.CrossFade("DoorClose");
		
		
		}
	}
}
