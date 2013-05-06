#pragma strict

var buttonWidth:float = 90.0f;
var buttonHeight:float = 30.0f;

function OnGUI () {
	var boxWidth:int = 600;
	var boxHeight:int = 400;

	GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
    	                    Screen.height / 2 - (boxHeight / 2), 
        	                boxWidth, boxHeight));

		var y:float = 0f;

		y += 30.0f;
		if (GUI.Button(Rect(70.0f, y, buttonWidth, buttonHeight), "Main Menu")) {
			Application.LoadLevel("sceneScreenMainMenu");
		}

		y += 30.0f;
		GUI.Label(Rect(60.0f, y, 290.0f, 50.0f), "Player Data");

		y += 15.0f;

		var maxPlayerIndex:int = scriptSceneManager2.MaxPlayerIndex();
    	for (var i:int = 1; i < maxPlayerIndex; i++) {
    		y += 20.0f;
        	GUI.Label(Rect(10.0f, y, 590.0f, y + 20.0f), String.Format("{0,2}. {1}", i, 
                  	  PlayerPrefs.GetString(scriptSceneManager2.PREF_PLAYER_DATA + i)));
    	}

	GUI.EndGroup();
}