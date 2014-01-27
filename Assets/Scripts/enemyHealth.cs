using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public float maxhealth = 100f;
	public float currentHealth;

	void Awake () {
		currentHealth = maxhealth;
	}

	void Update () {
		if(currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	public void TakeDamage (float damage){
		currentHealth -= damage;
	}

}
