using UnityEngine;
using System.Collections;

public class scriptScreenWin : MonoBehaviour {
	public float buttonWidth = 90.0f;
	public float buttonHeight = 30.0f;

	// Use this for initialization
	void OnGUI () {
		int boxWidth = 300;
		int boxHeight = 400;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			bool doesPlayerExist = PlayerPrefs.HasKey(scriptSceneManager.PREF_DOES_PLAYER_EXIST);
			float y = 0;

			GUI.Label(new Rect(60.0f, y, 290.0f, 50.0f), "Score: " + PlayerPrefs.GetInt(scriptSceneManager.PREF_SCORE));
			if (doesPlayerExist) {
				y += 30.0f;
				GUI.Label(new Rect(60.0f, y, 290.0f, 50.0f), "Player found! Score not recorded!");
			}

			y += 30.0f;
			if (GUI.Button(new Rect(70.0f, y, buttonWidth, buttonHeight), "Main Menu")) {
				Application.LoadLevel("sceneScreenMainMenu");
			}

			y += 30.0f;
			GUI.Label(new Rect(60.0f, y, 290.0f, 50.0f), "High Scores");

			y += 15.0f;

        	for (int i = 1; i <= 10; i++) {
        		y += 20.0f;
				string currentData = PlayerPrefs.GetString(scriptSceneManager.PREF_PLAYER_DATA + i);
				int score = 0;
				string firstName = "";
				string lastName = "";
				if (currentData.Length > 0) {
					score = int.Parse(currentData.Substring(currentData.LastIndexOf(",") + 1));
					int index = currentData.IndexOf(",");
					firstName = currentData.Substring(0, index);
					int index2 = currentData.IndexOf(",", index + 1);
					lastName = currentData.Substring(index + 1, index2 - index - 1);
				}

            	GUI.Label(new Rect(60.0f, y, 290.0f, y + 20.0f), string.Format("{0,2}. {1,10} : {2}", i, 
               		      score, firstName + " " + lastName));
        	}

		GUI.EndGroup();
	}
}
