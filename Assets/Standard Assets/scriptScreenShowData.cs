using UnityEngine;
using System.Collections;

public class scriptScreenShowData : MonoBehaviour {
	public float buttonWidth = 90.0f;
	public float buttonHeight = 30.0f;

	// Use this for initialization
	void OnGUI () {
		int boxWidth = 600;
		int boxHeight = 400;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			float y = 0f;

			y += 30.0f;
			if (GUI.Button(new Rect(70.0f, y, buttonWidth, buttonHeight), "Main Menu")) {
				Application.LoadLevel("sceneScreenMainMenu");
			}

			y += 30.0f;
			GUI.Label(new Rect(60.0f, y, 290.0f, 50.0f), "Player Data");

			y += 15.0f;

			int maxPlayerIndex = scriptSceneManager.MaxPlayerIndex();
        	for (int i = 1; i < maxPlayerIndex; i++) {
        		y += 20.0f;
            	GUI.Label(new Rect(10.0f, y, 590.0f, y + 20.0f), string.Format("{0,2}. {1}", i, 
                      	  PlayerPrefs.GetString(scriptSceneManager.PREF_PLAYER_DATA + i)));
        	}

		GUI.EndGroup();
	}
}
