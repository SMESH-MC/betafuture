#pragma strict

public var mySkin : GUISkin;
  
function OnGUI () {
	GUI.skin = mySkin;
        
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2-50,300,30),"Neues Spiel")){
	
	Application.LoadLevel(3);
	
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2,300,30),"Optionen")){
	
	Application.LoadLevel(1);
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+50,300,30),"Beenden")){
	
	Application.Quit();
	
	}
	
	if (GUI.Button (Rect(Screen.width/2-150,Screen.height/2+200,300,30),"Level Auswahl")){
	
	Application.LoadLevel(2);

	
	}
};