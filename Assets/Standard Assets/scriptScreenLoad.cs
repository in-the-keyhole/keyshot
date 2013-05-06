using UnityEngine;
using System.Collections;

public class scriptScreenLoad : MonoBehaviour {
	public float buttonWidth = 90.0f;
	public float buttonHeight = 50.0f;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel("Scene1");
		}
	}

	void OnGUI () {
		float boxWidth = 200.0f;
		float boxHeight = 220.0f;
		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
		                        Screen.height / 2 - (boxHeight / 2), 
		                        boxWidth, boxHeight));
	
			GUI.Box(new Rect(0, 0, boxWidth, boxHeight), "Instructions");
			float y = 30.0f;
			
			GUI.Label(new Rect(10.0f, y, 140.0f, 30.0f), "Arrow Keys to Move");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 160.0f, 30.0f), "Spacebar to Shoot");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 160.0f, 30.0f), "S for shield");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 160.0f, 30.0f), "Escape to Quit");
			y += 30.0f;
			GUI.Label(new Rect(10.0f, y, 160.0f, 30.0f), "Press Space to Start!");
		GUI.EndGroup();
	}
}
