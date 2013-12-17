using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{	
	public float phealth = 100f;					// The player's health.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player

	private GUITexture healthBar;				// Reference to the sprite renderer of the health bar.
	private GUIText healthBarText;

	private GameObject player;

	void Awake (){
		healthBar = GameObject.Find("HealthBar").GetComponent<GUITexture>();
		healthBar.color = Color.green;

		healthBarText = GameObject.Find("HealthBarText").GetComponent<GUIText>();
		healthBarText.text = phealth.ToString();

		player = GameObject.FindWithTag("Player");
	}

	void Update() {
		if (Input.GetButtonDown("HurtPlayer")){
			TakeDamage();
		}

		if(phealth <= 0) {
			Object.Destroy(player);
		}
	}

	void TakeDamage (){
		phealth -= damageAmount;
		UpdateHealthBar();
	}

	public void UpdateHealthBar (){
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.color = Color.Lerp(Color.green, Color.red, 1 - phealth * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.pixelInset = new Rect(0, 0 , (healthBar.pixelInset.width * phealth * 0.01f) + 10, 25);

		healthBarText.text = phealth.ToString();
	}
}
