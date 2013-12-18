using UnityEngine;
using System.Collections;

public class hitPlayer : MonoBehaviour {

	private health playerhealth;
	// Use this for initialization
	void Start () {
	
	}

    int Awake { 
		set { playerhealth = GameObject.FindWithTag ("Player").GetComponent<health> ();}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider player) {

		if(player.tag == "Player") {
			playerhealth.TakeDamage();
		}
	}

}
