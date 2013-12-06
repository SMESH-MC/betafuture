#pragma strict

public var mySkin : GUISkin;

function OnGUI () {

GUI.skin = mySkin;
        
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2-50,300,30),"Prolog")){
	
	Application.LoadLevel(3);
	
	}
	
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+100,300,30),"Zurück")){
	
	Application.LoadLevel(0);
	
	
	}
};