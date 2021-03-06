using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scriptSceneManager : MonoBehaviour {
	public static int   score = 0;
	public static int   lives = 3;
	public static int   shieldStrength = 2;
	public static bool  shieldOff = true;
	public static int   bonusScore = 10000;
	public static float timeToPlay = 30.0f;
	public static float gameTime = timeToPlay;
	
	public static string PREF_PLAYER_FIRST_NAME = "PLAYER_FIRST_NAME";
	public static string PREF_PLAYER_LAST_NAME  = "PLAYER_LAST_NAME";
	public static string PREF_PLAYER_PHONE      = "PLAYER_PHONE";
	public static string PREF_PLAYER_EMAIL      = "PLAYER_EMAIL";
	public static string PREF_DOES_PLAYER_EXIST = "DOES_PLAYER_EXIST";
	public static string PREF_SCORE             = "SCORE";
	public static string PREF_PLAYER_DATA       = "playerData";
	
	public static string TAG_PLAYER             = "Player";
	public static string TAG_ASTROID            = "Astroid";
	public static string TAG_SHIELD             = "Shield";

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		score = 0;
		lives = 3;
		shieldStrength = 3;
		shieldOff = true;
		gameTime = timeToPlay;
		InvokeRepeating("CountDown", 1.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			CancelInvoke("CountDown");
			PlayerPrefs.SetInt(PREF_SCORE, score);
			Application.LoadLevel("sceneScreenWin");
		}
	}

	public static void AddScore(int points) {
		score += points;
	}

	void CountDown() {
		gameTime -= 1.0f;
		if (gameTime <= 0.0f) {
			CancelInvoke("CountDown");
			PlayerPrefs.SetInt(PREF_SCORE, score);
			Application.LoadLevel("sceneScreenWin");
		}
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.richText = true;
		style.normal.textColor = Color.white;
		int size = scriptFont.GetSizeFromResolution();
		int y = size;
    	GUI.Label(new Rect(size, y, size * 10, size), scriptFont.MakeString("Time   : " + gameTime), style);
		y += size + 1;
		GUI.Label(new Rect(size, y, size * 10, size), scriptFont.MakeString("Score  : " + score), style);
		y += size + 1;
		GUI.Label(new Rect(size, y, size * 10, size), scriptFont.MakeString("Lives  : " + lives), style);
		if (!shieldOff) {
			y += size + 1;
			GUI.Label(new Rect(size, y, size * 10, size), scriptFont.MakeString("Shield : " + shieldStrength), style);	 
		}

		if (score >= bonusScore) {
			y += size + 1;
			GUI.Label(new Rect(size, y, size * 10, size), scriptFont.MakeString("AUTOFIRE", "red", true, true), style);
		}
	}

	public static void SaveHighScores(string playerData) {
		// wipe previous high scores since they aren't compatible
		if (!PlayerPrefs.HasKey("update.2")) {
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetString("update.2", "true");
		}
		
		int maxPlayerIndex = MaxPlayerIndex();
		List<KeyValuePair<int, string>> highScores = new List<KeyValuePair<int, string>>();

		// read in scores & names
    	for (int i = 1; i <= maxPlayerIndex; i++) {
			string currentData = PlayerPrefs.GetString(PREF_PLAYER_DATA + i);
			if (currentData.Length > 0) {
				int currentScore = int.Parse(currentData.Substring(currentData.LastIndexOf(",") + 1));
				KeyValuePair<int, string> highScore = new KeyValuePair<int, string>(currentScore, currentData);
				highScores.Add(highScore);
			}
		}

		// add current score in sorted position
		playerData += "," + score;
		KeyValuePair<int, string> newScore = new KeyValuePair<int, string>(score, playerData);
		bool playerInserted = false;
		for (int i = 0; i < highScores.Count; i++) {
			if (score > highScores[i].Key) {
				highScores.Insert(i, newScore);
				playerInserted = true;
				break;
			}
		}

		if (!playerInserted && highScores.Count < 10) {
			highScores.Add(newScore);
		}

		// write out new scores
		int scoresToSave = highScores.Count < 10 ? highScores.Count : 10;
    	for (int i = 0; i < scoresToSave; i++) {
    		PlayerPrefs.SetString(PREF_PLAYER_DATA + (i + 1), highScores[i].Value);
    	}

		PlayerPrefs.Save();
	}

	// returns the next index after the last player, or 10 if there are that many scores
	public static int MaxPlayerIndex() {
		int keyIndex = 1;
		while (PlayerPrefs.HasKey(PREF_PLAYER_DATA + keyIndex) && keyIndex < 10) {
			++keyIndex;
		}
		
		return keyIndex;
	}
}
