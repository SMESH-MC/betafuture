using UnityEngine;
using System.Collections;

public class hitPlayer : MonoBehaviour {
	public float damageAmount = 10.0f;

	//private health playerhealth;
	// Use this for initialization
	void Start () {
	
	}

    //int Awake { 
	//	set { playerhealth = GameObject.FindWithTag ("Player").GetComponent<health> ();}
	//}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider playerCollider) {

		if(playerCollider.tag == "Player") {
			GameObject player = GameObject.Find("Player");
			health playerHealth = (health) player.GetComponent(typeof(health));
			playerHealth.TakeDamage(damageAmount);
			//playerhealth.TakeDamage();
		}
	}

}
