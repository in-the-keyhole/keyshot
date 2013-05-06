using UnityEngine;
using System.Collections;

public class scriptScreenMainMenu : MonoBehaviour {
	public float buttonWidth = 90.0f;
	public float buttonHeight = 30.0f;
	string hidden = "";
	int numberOfButtons = 4;

	// Update is called once per frame
	void Update () {
		string input = Input.inputString;
		if (input.Length > 0) {
			hidden += input;
		}

		if (hidden.Contains("key")) {
			numberOfButtons = 6;
		} else if (hidden.Length > 10) {
			hidden = "";
		}
	}
	
	void OnGUI () {
		float boxWidth = buttonWidth + 20.0f;
		float boxHeight = ((buttonHeight + 10.0f) * numberOfButtons) + 30.0f;
		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), "Main Menu");
			float y = 30.0f;

			if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Start Game")) {
				Application.LoadLevel("sceneScreenGetPlayerInfo");
			}

			y += buttonHeight + 10.0f;
			if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Credits")) {
				Application.LoadLevel("sceneScreenCredits");
			}

			y += buttonHeight + 10.0f;
			if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Homepage")) {
				Application.OpenURL("http://www.keyholesoftware.com/");
			}

			y += buttonHeight + 10.0f;
			if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Exit Game")) {
				Application.Quit();
			}

			if (numberOfButtons == 6) {
				y += buttonHeight + 10.0f;
				if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Show Data")) {
					Application.LoadLevel("sceneScreenShowData");
				}

				y += buttonHeight + 10.0f;
				if (GUI.Button(new Rect(10.0f, y, buttonWidth, buttonHeight), "Clear Data")) {
					PlayerPrefs.DeleteAll();
				}
			}
		
		GUI.EndGroup();
	}
}
