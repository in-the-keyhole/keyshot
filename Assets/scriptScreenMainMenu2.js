#pragma strict

var buttonWidth:float = 90;
var buttonHeight:float = 50;
var numberOfButtons:int = 4;
var hidden:String = "";

// Update is called once per frame
function Update () {
	var input:String = Input.inputString;
	if (input.Length > 0) {
		hidden += input;
	}

	if (hidden.Contains("key")) {
		numberOfButtons = 6;
	} else if (hidden.Length > 10) {
		hidden = "";
	}
}

function OnGUI () {
	var boxWidth:int = buttonWidth + 20;
	var boxHeight:int = ((buttonHeight + 10) * numberOfButtons) + 30;

	GUI.BeginGroup(Rect(Screen.width / 2 - (boxWidth / 2), 
	                    Screen.height / 2 - (boxHeight / 2), 
	                    boxWidth, boxHeight));

		GUI.Box(Rect(0, 0, boxWidth, boxHeight), "Main Menu");
		var y:int = 30;

		if (GUI.Button(Rect(10, y, buttonWidth, buttonHeight), "Start Game")) {
			Application.LoadLevel("sceneScreenGetPlayerInfo");
		}

		y += buttonHeight + 10;
		if (GUI.Button(Rect(10, y, buttonWidth, buttonHeight), "Credits")) {
			Application.LoadLevel("sceneScreenCredits");
		}

		y += buttonHeight + 10;
		if (GUI.Button(Rect(10, y, buttonWidth, buttonHeight), "Homepage")) {
			Application.OpenURL("http://www.keyholesoftware.com/");
		}

		y += buttonHeight + 10;
		if (GUI.Button(Rect(10, y, buttonWidth, buttonHeight), "Exit Game")) {
			Application.Quit();
		}

		if (numberOfButtons == 6) {
			y += buttonHeight + 10.0f;
			if (GUI.Button(Rect(10.0f, y, buttonWidth, buttonHeight), "Show Data")) {
				Application.LoadLevel("sceneScreenShowData");
			}
	
			y += buttonHeight + 10.0f;
			if (GUI.Button(Rect(10.0f, y, buttonWidth, buttonHeight), "Clear Data")) {
				PlayerPrefs.DeleteAll();
			}
		}

	GUI.EndGroup();
}
