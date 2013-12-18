#pragma strict
var levelauswahl = 2;

function OnControllerColliderHit(hit : ControllerColliderHit){
	if (hit.gameObject.tag == "Finish"){
		Application.LoadLevel(levelauswahl);
	}
}