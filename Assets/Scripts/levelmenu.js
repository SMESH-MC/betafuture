#pragma strict

public var mySkin : GUISkin;

function OnGUI () {

GUI.skin = mySkin;

        
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2-50,300,30),"Prolog")){
	
	Application.LoadLevel(3);
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2,300,30),"Level 1")){
	
	//Application.LoadLevel("level1");
	print ("Auskommentieren #2");
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+50,300,30),"Level 2")){
	
	//Application.LoadLevel("level2");
	print ("Auskommentieren #2");
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+100,300,30),"Zurück")){
	
	Application.LoadLevel(0);
	
	
	}
};