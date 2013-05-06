#pragma strict

var buttonWidth:float = 70;
var buttonHeight:float = 30;

function OnGUI () {
	var boxWidth:int = 200;
	var boxHeight:int = 200;
	GUI.BeginGroup(Rect(Screen.width / 2 - (boxWidth / 2), 
	                    Screen.height / 2 - (boxHeight / 2), 
	                    boxWidth, boxHeight));

		GUI.Box(Rect(0, 0, boxWidth, boxHeight), "Credits");
		var y:int = 40;

		GUI.Label(Rect(10, y, 200, 50),	"Designer			John Boardman");
		y += 30;
		GUI.Label(Rect(10, y, 200, 80),	"Artist					John Boardman");
		y += 30;
		GUI.Label(Rect(10, y, 200, 110),	"Software			John Boardman");
		y += 30;
		GUI.Label(Rect(10, y, 200, 110),	"Level Designer	John Boardman");

		y += 30;
		if (GUI.Button(Rect(60, y, buttonWidth, buttonHeight), "Back")) {
			Application.LoadLevel("sceneScreenMainMenu");
		}

	GUI.EndGroup();
}
