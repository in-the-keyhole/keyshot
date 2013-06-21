using UnityEngine;
using System.Collections;

public class scriptScreenCredits : MonoBehaviour {
	void Start() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	void OnGUI () {
		int size = scriptFont.GetSizeFromResolution();
		GUIStyle style = new GUIStyle();
		style.richText = true;
		style.normal.textColor = Color.white;

		GUIStyle boxStyle = GUI.skin.box;
		boxStyle.richText = true;
		boxStyle.normal.textColor = Color.white;

		GUIStyle buttonStyle = GUI.skin.button;
		buttonStyle.richText = true;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.fontSize = size;
		
		float spacer = 5f;
		float spacerX2 = 10f;
		float boxWidth = size * 30.0f;
		float boxHeight = size * 15.0f;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
		                        Screen.height / 2 - (boxHeight / 2), 
		                        boxWidth, boxHeight));

			GUI.Box(new Rect(0, 0, boxWidth, boxHeight),          scriptFont.MakeString("Credits"), boxStyle);
			float y = size + spacerX2;
			GUI.Label(new Rect(spacerX2, y, size * 9, size),         scriptFont.MakeString("Designer"), style);
			GUI.Label(new Rect(boxWidth / 2, y, size * 14, size), scriptFont.MakeString("John Boardman"), style);
			y += size + spacer;
			GUI.Label(new Rect(spacerX2, y, size * 9, size),         scriptFont.MakeString("Artist"), style);
			GUI.Label(new Rect(boxWidth / 2, y, size * 14, size), scriptFont.MakeString("John Boardman"), style);
			y += size + spacer;
			GUI.Label(new Rect(spacerX2, y, size * 9, size),         scriptFont.MakeString("Software"), style);
			GUI.Label(new Rect(boxWidth / 2, y, size * 14, size), scriptFont.MakeString("John Boardman"), style);
			y += size + spacer;
			GUI.Label(new Rect(spacerX2, y, size * 9, size),         scriptFont.MakeString("Levels"), style);
			GUI.Label(new Rect(boxWidth / 2, y, size * 14, size), scriptFont.MakeString("John Boardman"), style);

			y += size + spacerX2;
			if (GUI.Button(new Rect((boxWidth / 2.0f) - (size * 3.0f), y, size * 5.0f, size * 2.3f), "Back", buttonStyle)) {
				Application.LoadLevel("sceneScreenMainMenu");
			}
	
		GUI.EndGroup();
	}
}
