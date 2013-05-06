#pragma strict

var buttonWidth:float = 90;
var buttonHeight:float = 50;

function Update() {
	if (Input.GetKeyDown(KeyCode.Space)) {
		Application.LoadLevel("Scene1");
	}
}

function OnGUI () {
	var boxWidth:float = 200.0f;
	var boxHeight:float = 220.0f;
	GUI.BeginGroup(Rect(Screen.width / 2 - (boxWidth / 2), 
	                    Screen.height / 2 - (boxHeight / 2), 
	                    boxWidth, boxHeight));

		GUI.Box(Rect(0, 0, boxWidth, boxHeight), "Instructions");
		var y:float = 30.0f;
		
		GUI.Label(Rect(10.0f, y, 140.0f, 30.0f),"Arrow Keys to Move");
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 160.0f, 30.0f),"Spacebar to Shoot");
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 160.0f, 30.0f),"S for shield");
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 160.0f, 30.0f),"Escape to Quit");
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 160.0f, 30.0f), "Press Space to Start!");
	GUI.EndGroup();
}
