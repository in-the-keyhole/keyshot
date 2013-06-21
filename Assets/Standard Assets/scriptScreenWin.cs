using UnityEngine;
using System.Collections;

public class scriptScreenWin : MonoBehaviour {
	private static string[] CHARS = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
		                             "1","2","3","4","5","6","7","8","9","0","!","@","#","$","%","^","&","*","-","_","<",">","?","/","'","."};
	
	public Texture upArrowTexture;
	public Texture dnArrowTexture;
	
	private bool   scoreSaved    = false;
	private string firstInitial  = "A";
	private string middleInitial = "A";
	private string lastInitial   = "A";

	private int IndexOfChar(string current) {
		int i = 0;
		while (CHARS[i] != current) {
			++i;
		}

		return i;
	}

	private string PrevChar(string current) {
		int index = IndexOfChar(current);
		if (index > 0) {
			--index;
		} else {
			index = CHARS.Length - 1;
		}
		
		return CHARS[index];
	}

	private string NextChar(string current) {
		int index = IndexOfChar(current);
		if (index < CHARS.Length - 1) {
			++index;
		} else {
			index = 0;
		}
		
		return CHARS[index];
	}
	
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

		float sizeX2 = size * 2;
		float sizeX3 = size * 3;
		float boxWidth = size * 30.0f;
		float boxHeight = size * 20.0f;
		float left = (boxWidth / 2.0f) - (size * 3.0f);
		float spacer = size + 5;
		float buttonWidth = size * 10.0f;
		float buttonHeight = size * 3f;

		GUI.BeginGroup(new Rect(Screen.width / 2 - (boxWidth / 2), 
	    	                    Screen.height / 2 - (boxHeight / 2), 
	        	                boxWidth, boxHeight));

			float y = 0;

			GUI.Label(new Rect(left, y, size * 20.0f, size), scriptFont.MakeString("Score: " + PlayerPrefs.GetInt(scriptSceneManager.PREF_SCORE)), style);
			y += spacer;

			if (!scoreSaved) {
				y += spacer;

				GUI.Label(new Rect(left, y, sizeX2, sizeX2), scriptFont.MakeString(firstInitial), style);
				GUI.Label(new Rect(left + sizeX3, y, sizeX2, sizeX2), scriptFont.MakeString(middleInitial), style);
				GUI.Label(new Rect(left + sizeX3 + sizeX3, y, sizeX2, sizeX2), scriptFont.MakeString(lastInitial), style);
				y += size + sizeX2;
				
				if (GUI.Button(new Rect(left, y, sizeX3, sizeX3), upArrowTexture)) {
					firstInitial = NextChar(firstInitial);
				}

				if (GUI.Button(new Rect(left + sizeX3, y, sizeX3, sizeX3), upArrowTexture)) {
					middleInitial = NextChar(middleInitial);
				}

				if (GUI.Button(new Rect(left + sizeX3 + sizeX3, y, sizeX3, sizeX3), upArrowTexture)) {
					lastInitial = NextChar(lastInitial);
				}
				y += sizeX3;
				
				if (GUI.Button(new Rect(left, y, sizeX3, sizeX3), dnArrowTexture)) {
					firstInitial = PrevChar(firstInitial);
				}

				if (GUI.Button(new Rect(left + sizeX3, y, sizeX3, sizeX3), dnArrowTexture)) {
					middleInitial = PrevChar(middleInitial);
				}

				if (GUI.Button(new Rect(left + sizeX3 + sizeX3, y, sizeX3, sizeX3), dnArrowTexture)) {
					lastInitial = PrevChar(lastInitial);
				}

				y += sizeX3 + sizeX2;
				if (GUI.Button(new Rect(left, y, buttonWidth, buttonHeight), "SAVE", buttonStyle)) {
					string initials = firstInitial + middleInitial + lastInitial;
					scriptSceneManager.SaveHighScores(initials);
					scoreSaved = true;
				}
			} else {
				y += spacer;
				if (GUI.Button(new Rect(left, y, buttonWidth, buttonHeight), "Main Menu", buttonStyle)) {
					Application.LoadLevel("sceneScreenMainMenu");
				}

				y += buttonHeight;
				GUI.Label(new Rect(left, y, size * 20.0f, size), scriptFont.MakeString("High Scores"), style);
	
				y += spacer;
	        	for (int i = 1; i <= scriptSceneManager.MaxPlayerIndex(); i++) {
					string currentData = PlayerPrefs.GetString(scriptSceneManager.PREF_PLAYER_DATA + i);
					int score = 0;
					string initials = "";
					if (currentData.Length > 0) {
						score = int.Parse(currentData.Substring(currentData.LastIndexOf(",") + 1));
						int index = currentData.IndexOf(",");
						initials = currentData.Substring(0, index);

		            	GUI.Label(new Rect(left, y, size * 20.0f, size), scriptFont.MakeString(string.Format("{0,2}. {1,10} : {2}", i, 
		               		      score, initials)), style);
		        		y += spacer;
					}
	        	}
			}

		GUI.EndGroup();
	}
}
