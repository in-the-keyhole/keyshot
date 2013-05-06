using UnityEngine;
using System.Collections;

public class scriptScreenCredits : MonoBehaviour {
	public float buttonWidth = 70.0f;
	public float buttonHeight = 30.0f;

	void OnGUI () {
		float boxWidth = 200.0f;
		float boxHeight = 200.0f;
		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
		                        Screen.height / 2 - (boxHeight / 2), 
		                        boxWidth, boxHeight));
	
			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), "Credits");
			float y = 40.0f;
	
			GUI.Label(new Rect(10.0f, y, 200.0f, 50.0f),	"Designer			John Boardman");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 200.0f, 80.0f),	"Artist					John Boardman");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 200.0f, 110.0f),	"Software			John Boardman");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 200.0f, 110.0f),	"Level Designer	John Boardman");
	
			y += 30.0f;
			if (GUI.Button(new Rect(60.0f, y, buttonWidth, buttonHeight), "Back")) {
				Application.LoadLevel("sceneScreenMainMenu");
			}
	
		GUI.EndGroup();
	}
}
