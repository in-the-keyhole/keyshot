using UnityEngine;
using System.Collections;

public class scriptScreenMainMenu : MonoBehaviour {
	string hidden = "";
	int numberOfButtons = 5;

	void Start() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update() {
		string input = Input.inputString;
		if (input.Length > 0) {
			hidden += input;
		}

		bool touched = false;
		if (SystemInfo.supportsAccelerometer) {
			foreach (Touch touch in Input.touches) {
				if (Input.touchCount == 3 && touch.phase == TouchPhase.Began) {
					touched = true;
					break;
				}
			}
		}
		
		if (hidden.Contains("key") || touched) {
			numberOfButtons = 6;
		} else if (hidden.Length > 10) {
			hidden = "";
		}
	}
	
	void OnGUI () {
		int size = scriptFont.GetSizeFromResolution();
		GUIStyle boxStyle = GUI.skin.box;
		boxStyle.richText = true;
		boxStyle.normal.textColor = Color.white;

		GUIStyle buttonStyle = GUI.skin.button;
		buttonStyle.richText = true;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.fontSize = size;
		
		float spacer = 5f;
		float boxWidth = size * 9f;
		float boxHeight = size * 4f * numberOfButtons;
		float buttonWidth = size * 7;
		float buttonHeight = size * 2.3f;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), scriptFont.MakeString("Main Menu"), boxStyle);
			float y = buttonHeight + spacer;

			if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Start Game", buttonStyle)) {
				Application.LoadLevel("sceneScreenLoad");
			}

			y += buttonHeight + spacer;
			if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Credits", buttonStyle)) {
				Application.LoadLevel("sceneScreenCredits");
			}

			y += buttonHeight + spacer;
			if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Homepage", buttonStyle)) {
				Application.OpenURL("http://www.keyholesoftware.com/");
			}

			if (SystemInfo.supportsAccelerometer) {
				y += buttonHeight + spacer;
				if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Settings", buttonStyle)) {
					Application.LoadLevel("sceneScreenSettings");
				}
			}

			y += buttonHeight + spacer;
			if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Exit Game", buttonStyle)) {
				Application.Quit();
			}

			if (numberOfButtons == 6) {
				y += buttonHeight + spacer;
				if (GUI.Button(new Rect(size, y, buttonWidth, buttonHeight), "Clear Data", buttonStyle)) {
					PlayerPrefs.DeleteAll();
				}
			}
		
		GUI.EndGroup();
	}
}
