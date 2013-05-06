#pragma strict

var buttonWidth:float = 90.0f;
var buttonHeight:float = 40.0f;
var firstName:String = "";
var lastName:String = "";
var phone:String = "";
var email:String = "";

function Start() {
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_PLAYER_FIRST_NAME);
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_PLAYER_LAST_NAME);
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_PLAYER_PHONE);
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_PLAYER_EMAIL);
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_DOES_PLAYER_EXIST);
	PlayerPrefs.DeleteKey(scriptSceneManager2.PREF_SCORE);
}

function OnGUI () {
	var boxWidth:float = 300.0f;
	var boxHeight:float = 230.0f;
	GUI.BeginGroup(Rect(Screen.width / 2 - (boxWidth / 2), 
	                    Screen.height / 2 - (boxHeight / 2), 
	                    boxWidth, boxHeight));

		GUI.Box(Rect(0, 0, boxWidth, boxHeight), "Enter Your Info!");
		var y:float = 30.0f;
		
		GUI.Label(Rect(10.0f, y, 80.0f, 40.0f), "First Name");
		firstName = GUI.TextField(Rect(90.0f, y, 200.0f, 30.0f), firstName, 40);
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 80.0f, 70.0f), "Last Name");
		lastName = GUI.TextField(Rect(90.0f, y, 200.0f, 30.0f), lastName, 40);
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 80.0f, 100.0f), "Phone #");
		phone = GUI.TextField(Rect(90.0f, y, 200.0f, 30.0f), phone, 40);
		y += 30.0f;
		GUI.Label(Rect(10.0f, y, 80.0f, 100.0f), "email");
		email = GUI.TextField(Rect(90.0f, y, 200.0f, 30.0f), email, 40);
		y += 40.0f;
		if (GUI.Button(Rect(90.0f, y, buttonWidth, buttonHeight), "Save Info")) {
			// here is where you would validate data if it is required
			
			PlayerPrefs.SetString(scriptSceneManager2.PREF_PLAYER_FIRST_NAME, firstName);
			PlayerPrefs.SetString(scriptSceneManager2.PREF_PLAYER_LAST_NAME,  lastName);
			PlayerPrefs.SetString(scriptSceneManager2.PREF_PLAYER_PHONE, phone);
			PlayerPrefs.SetString(scriptSceneManager2.PREF_PLAYER_EMAIL, email);

			Application.LoadLevel("sceneScreenLoad");
		}

	GUI.EndGroup();
}
