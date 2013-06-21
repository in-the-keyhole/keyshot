using UnityEngine;
using System.Collections;

public class scriptScreenLoad : MonoBehaviour {
	void Start() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) {
			Application.LoadLevel("Scene1");
		}
	}

	void OnGUI () {
		int size = scriptFont.GetSizeFromResolution();
		GUIStyle style = new GUIStyle();
		style.richText = true;
		style.normal.textColor = Color.white;

		GUIStyle boxStyle = GUI.skin.box;
		boxStyle.richText = true;
		boxStyle.normal.textColor = Color.white;

		float spacerX2 = size * 2f;
		float boxWidth = size * 22.0f;
		float boxHeight = size * 14.0f;
		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
		                        Screen.height / 2 - (boxHeight / 2), 
		                        boxWidth, boxHeight));
	
			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), scriptFont.MakeString("Instructions"), boxStyle);
			float y = spacerX2;
			
			GUI.Label(new Rect(spacerX2, y, size * 20f, size), scriptFont.MakeString("Arrows/Tilt to Move"), style);
			y += spacerX2;
			GUI.Label(new Rect(spacerX2, y, size * 20f, size), scriptFont.MakeString("Space/Tap to Shoot"), style);
			y += spacerX2;
			GUI.Label(new Rect(spacerX2, y, size * 20f, size), scriptFont.MakeString("S/2 Fingers for shield"), style);
			y += spacerX2;
			GUI.Label(new Rect(spacerX2, y, size * 20f, size), scriptFont.MakeString("10000 for AUTOFIRE!"), style);
			y += spacerX2;
			GUI.Label(new Rect(spacerX2, y, size * 20f, size), scriptFont.MakeString("Space/Tap to Start!"), style);
		GUI.EndGroup();
	}
}
