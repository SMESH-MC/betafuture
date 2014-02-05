using UnityEngine;
using System.Collections;

public class LevelChangerFixed : MonoBehaviour {

	public int levelauswahl = 6;

 	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player") {
			Application.LoadLevel(levelauswahl);
		}
	}
}
