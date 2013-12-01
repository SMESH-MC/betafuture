#pragma strict

function OnGUI () {

        
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2-50,300,30),"Prolog")){
	
	Application.LoadLevel("test");
	
	}
	
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+100,300,30),"Zurück")){
	
	Application.LoadLevel("mainmenu");
	
	
	}
};