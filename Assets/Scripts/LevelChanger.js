#pragma strict

function OnControllerColliderHit(hit : ControllerColliderHit){
	if (hit.gameObject.tag == "Finish"){
		Application.LoadLevel("level2");
	}
}