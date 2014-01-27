using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{	
	public float maxhealth = 100f;					// The player's health.
	private float currentHealth;
	public float maxShield = 100f;
	private float currentShield;
	public float damageAmount = 8f;			// The amount of damage to take when enemies touch the player

	private GUITexture healthBar;				// Reference to the sprite renderer of the health bar.
	private GUIText healthBarText;
	private float healthScale;
	private float shieldScale;

	private GUITexture shieldBar;
	private GUIText shieldBarText;

	private int onScreenX;
	private int onScreenY;
	private int heigth = 25;

	private GameObject player;

	void Awake () {
		onScreenX = Screen.width / 100; // 1 % der Weite
		onScreenY = Screen.height - (Screen.height / 10); // 90 % der Hoehe

		currentHealth = maxhealth;
		currentShield = maxShield;

		healthScale = onScreenX * 20;
		shieldScale = onScreenX * 18;

		healthBar = GameObject.Find("HealthBar").GetComponent<GUITexture>();
		healthBar.color = Color.green;
		healthBar.pixelInset = new Rect (onScreenX + (int)(onScreenX * (maxhealth - currentHealth)/200),onScreenY,healthScale,heigth);


		healthBarText = GameObject.Find("HealthBarText").GetComponent<GUIText>();
		healthBarText.text = currentHealth.ToString();
		healthBarText.pixelOffset = new Vector2 (onScreenX, onScreenY + 25);

		shieldBar = GameObject.Find("ShieldBar").GetComponent<GUITexture>();
		shieldBar.color = Color.blue;
		shieldBar.pixelInset = new Rect (onScreenX + (int)(onScreenX * (maxShield - currentShield)/200),onScreenY - 30 ,shieldScale,heigth);


		player = GameObject.FindWithTag("Player");


	}

	void Update() {
		if (Input.GetButtonDown("HurtPlayer")){
			TakeDamage(damageAmount);
		}

		if(currentHealth <= 0) {
			Object.Destroy(player);
		}
	}

	public void TakeDamage (float hit){
		float damage = (maxShield - currentShield)/100 * hit;
		currentShield -= hit;
		currentHealth -= damage; 
		if ( currentHealth > 0 && currentShield < 0){
			currentShield = 0f;
		} else if (currentHealth < 0 && currentShield < 0){
			currentShield = 0f;
			currentHealth = 0f;
		}
		UpdateBars();
	}

	public void UpdateBars (){
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.color = Color.Lerp(Color.green, Color.red, (1 -currentHealth * 0.01f)*1.5f);

		float newWidthHealth = healthScale * (currentHealth/100);
		float newWidthShield = shieldScale * (currentShield/100);
		//float newXPosition = onScreenX + (int)(onScreenX * (maxhealth - currentHealth)/200);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.pixelInset = new Rect(onScreenX, onScreenY,newWidthHealth, heigth);

		shieldBar.pixelInset = new Rect(onScreenX, onScreenY - 30,newWidthShield, heigth);

		//healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);

		healthBarText.text = currentHealth.ToString();
	}
}
