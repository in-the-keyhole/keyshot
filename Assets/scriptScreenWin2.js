#pragma strict

var buttonWidth:float = 90;
var buttonHeight:float = 30;

function OnGUI () {
	var boxWidth:int = 300;
	var boxHeight:int = 400;
	
	GUI.BeginGroup(Rect(Screen.width / 2 - (boxWidth / 2), 
	                    Screen.height / 2 - (boxHeight / 2), 
	                    boxWidth, boxHeight));

		var doesPlayerExist:boolean = PlayerPrefs.HasKey(scriptSceneManager2.PREF_DOES_PLAYER_EXIST);
		var y:float = 0f;

		GUI.Label(Rect(60.0f, y, 290.0f, 50.0f), "Score: " + PlayerPrefs.GetInt(scriptSceneManager2.PREF_SCORE));
		if (doesPlayerExist) {
			y += 30.0f;
			GUI.Label(Rect(60.0f, y, 290.0f, 50.0f), "Player found! Score not recorded!");
		}

		y += 30.0f;
		if (GUI.Button(Rect(70.0f, y, buttonWidth, buttonHeight), "Main Menu")) {
			Application.LoadLevel("sceneScreenMainMenu");
		}

		y += 30.0f;
		GUI.Label(Rect(60.0f, y, 290.0f, 50.0f), "High Scores");

		y += 15.0f;

        for (var i:int = 1; i <= 10; i++) {
    		y += 20.0f;
			var currentData:String = PlayerPrefs.GetString(scriptSceneManager2.PREF_PLAYER_DATA + i);
			var score:int = 0;
			var firstName:String = "";
			var lastName:String = "";
			if (currentData.Length > 0) {
				score = int.Parse(currentData.Substring(currentData.LastIndexOf(",") + 1));
				var index:int = currentData.IndexOf(",");
				firstName = currentData.Substring(0, index);
				var index2:int = currentData.IndexOf(",", index + 1);
				lastName = currentData.Substring(index + 1, index2 - index - 1);
			}

        	GUI.Label(Rect(60.0f, y, 290.0f, y + 20.0f), String.Format("{0,2}. {1,10} : {2}", i, 
           		      score, firstName + " " + lastName));
    	}

	GUI.EndGroup();
}
