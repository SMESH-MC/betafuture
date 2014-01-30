using UnityEngine;
using System.Collections;

public class bulletEnemy : MonoBehaviour {
		
		public float damage = 100f;
		private GameObject target;
		private enemyHealth targetHealth;	
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnCollisionEnter(Collision collision){
			target = collision.gameObject;
			
			if(target.tag == "Player") {
				Debug.Log("Player hit");
				doDamage(target);
			} else {
				Debug.Log("NOENEMY");
			}
			Destroy(gameObject);
		}
		
		void doDamage (GameObject target) {
			targetHealth = target.GetComponent<enemyHealth>();
			targetHealth.TakeDamage(damage);
			float tHealth = targetHealth.currentHealth;
			Debug.Log(tHealth.ToString());
		}
	}
