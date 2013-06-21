using UnityEngine;
using System.Collections;

public class scriptScreenSettings : MonoBehaviour {
	void Start() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Use this for initialization
	void OnGUI () {
		int size = scriptFont.GetSizeFromResolution();
		GUIStyle style = new GUIStyle();
		style.richText = true;
		style.normal.textColor = Color.white;

		GUIStyle buttonStyle = GUI.skin.button;
		buttonStyle.richText = true;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.fontSize = size + 2;

		float boxWidth = size * 30.0f;
		float boxHeight = size * 20.0f;
		float left = (boxWidth / 2.0f) - (size * 3.0f);
		float buttonWidth = size * 10.0f;
		float buttonHeight = size * 3f;
		float spacer = buttonHeight + size;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			float y = 0;
			GUI.Label(new Rect((boxWidth / 2.0f) - (size * 4.0f), y, size * 25.0f, size), scriptFont.MakeString("NOTE: BLUETOOTH KEYBOARD", "red"), style);
			y += size;
			GUI.Label(new Rect((boxWidth / 2.0f) - (size * 4.0f), y, size * 25.0f, size), scriptFont.MakeString("ONLY WORKS ON ANDROID", "red"), style);
			y += size;
			string pref = PlayerPrefs.HasKey("keyshot.input") ? PlayerPrefs.GetString("keyshot.input") : "touchscreen";
			GUI.Label(new Rect(left, y, size * 25.0f, size), scriptFont.MakeString("Current: " + pref), style);

			y += size + size;
			if (GUI.Button(new Rect(left, y, buttonWidth, buttonHeight), "Use BT Keyboard", buttonStyle)) {
				PlayerPrefs.SetString("keyshot.input", "keyboard");
			}

			y += spacer;
			if (GUI.Button(new Rect(left, y, buttonWidth, buttonHeight), "Use Touchscreen", buttonStyle)) {
				PlayerPrefs.SetString("keyshot.input", "touchscreen");
			}

			y += spacer;
			if (GUI.Button(new Rect(left, y, buttonWidth, buttonHeight), "Main Menu", buttonStyle)) {
				Application.LoadLevel("sceneScreenMainMenu");
			}

		GUI.EndGroup();
	}
}
