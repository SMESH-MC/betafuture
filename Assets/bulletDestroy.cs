using UnityEngine;
using System.Collections;

public class bulletDestroy : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(){
		Destroy(gameObject);
	}
}
