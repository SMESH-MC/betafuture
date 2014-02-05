using UnityEngine;
using System.Collections;

public class camera_lock : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	public GUIText deadscreen;
	private Transform player;		// Reference to the player.

	private int onScreenX;
	private int onScreenY;
	public int loadedLevel;
	
	void Awake ()
	{
		loadedLevel = Application.loadedLevel;
		deadscreen = GameObject.Find("deadscreen").GetComponent<GUIText>();
		onScreenX = Screen.width/2;
		onScreenY = Screen.height/2;
		deadscreen.pixelOffset = new Vector2(onScreenX, onScreenY);
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
	{
		if(player != null) {
			deadscreen.enabled = false;
		// Set the position to the player's position with the offset.
		transform.position = player.position + offset;
		}
		else {
			deadscreen.enabled = true;
			if(Input.GetButtonDown("Jump")) {
				Application.LoadLevel(loadedLevel);
			}
		}
	}
}
