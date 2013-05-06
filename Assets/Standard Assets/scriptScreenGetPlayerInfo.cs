using UnityEngine;
using System.Collections;

public class scriptScreenGetPlayerInfo : MonoBehaviour {
	public float buttonWidth = 90.0f;
	public float buttonHeight = 40.0f;
	string firstName = "";
	string lastName = "";
	string phone = "";
	string email = "";

	void Start() {
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_PLAYER_FIRST_NAME);
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_PLAYER_LAST_NAME);
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_PLAYER_PHONE);
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_PLAYER_EMAIL);
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_DOES_PLAYER_EXIST);
		PlayerPrefs.DeleteKey(scriptSceneManager.PREF_SCORE);
	}
	
	void OnGUI () {
		print("OnGUI()");
		float boxWidth = 300.0f;
		float boxHeight = 230.0f;
		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
		                        Screen.height / 2 - (boxHeight / 2), 
		                        boxWidth, boxHeight));
	
			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), "Enter Your Info!");
			float y = 30.0f;
			
			GUI.Label(new Rect(10.0f, y, 80.0f, 40.0f), "First Name");
			firstName = GUI.TextField(new Rect(90.0f, y, 200.0f, 30.0f), firstName, 40);
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 80.0f, 70.0f), "Last Name");
			lastName = GUI.TextField(new Rect(90.0f, y, 200.0f, 30.0f), lastName, 40);
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 80.0f, 100.0f), "Phone #");
			phone = GUI.TextField(new Rect(90.0f, y, 200.0f, 30.0f), phone, 40);
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 80.0f, 100.0f), "email");
			email = GUI.TextField(new Rect(90.0f, y, 200.0f, 30.0f), email, 40);
			y += 40.0f;
			if (GUI.Button(new Rect(90.0f, y, buttonWidth, buttonHeight), "Save Info")) {
				// here is where you would validate data if it is required
			
				PlayerPrefs.SetString(scriptSceneManager.PREF_PLAYER_FIRST_NAME, firstName);
				PlayerPrefs.SetString(scriptSceneManager.PREF_PLAYER_LAST_NAME,  lastName);
				PlayerPrefs.SetString(scriptSceneManager.PREF_PLAYER_PHONE, phone);
				PlayerPrefs.SetString(scriptSceneManager.PREF_PLAYER_EMAIL, email);

				Application.LoadLevel("sceneScreenLoad");
			}
		GUI.EndGroup();
	}
}
