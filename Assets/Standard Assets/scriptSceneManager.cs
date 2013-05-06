using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scriptSceneManager : MonoBehaviour {
	public static int   score = 0;
	public static int   lives = 3;
	public static int   shieldStrength = 2;
	public static bool  shieldOff = true;
	public static int   winScore = 10000;
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
			saveHighScores();
		}
	}

	public static void AddScore(int points) {
		score += points;
	}

	void CountDown() {
		gameTime -= 1.0f;
		if (gameTime <= 0.0f) {
			saveHighScores();
		}
	}

	void OnGUI() {
    	GUI.Label(new Rect(10, 10, 100, 35), "Time   : " + gameTime);	 
		GUI.Label(new Rect(10, 25, 100, 20), "Score  : " + score);
		GUI.Label(new Rect(10, 40, 100, 35), "Lives  : " + lives);
		if (!shieldOff) {
			GUI.Label(new Rect(10, 55, 100, 50), "Shield : " + shieldStrength);	 
		}
	}

	void saveHighScores() {
		CancelInvoke("CountDown");
		PlayerPrefs.SetInt(PREF_SCORE, score);

		// this data is how we form the key to search for the player
		string playerData = MakePlayerKey();
		int keyIndex = PlayerIndex(playerData);

		if (keyIndex > 0) {
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
			
			if (!playerInserted) {
				highScores.Add(newScore);
			}

			// write out new scores including new player
	    	for (int i = 0; i < highScores.Count; i++) {
	    		PlayerPrefs.SetString(PREF_PLAYER_DATA + (i + 1), highScores[i].Value);
	    	}

			PlayerPrefs.Save();
		} else {
			PlayerPrefs.SetString(PREF_DOES_PLAYER_EXIST, "TRUE");
		}

		Application.LoadLevel("sceneScreenWin");
	}

	// returns the next index after the last player
	public static int MaxPlayerIndex() {
		int keyIndex = 1;
		while (PlayerPrefs.HasKey(PREF_PLAYER_DATA + keyIndex)) {
			++keyIndex;
		}
		
		return keyIndex;
	}

	public static string MakePlayerKey() {
		// this data is how we form the key to search for the player
		string firstName = PlayerPrefs.GetString(PREF_PLAYER_FIRST_NAME);
		string lastName = PlayerPrefs.GetString(PREF_PLAYER_LAST_NAME);
		string phone = PlayerPrefs.GetString(PREF_PLAYER_PHONE);
		string email = PlayerPrefs.GetString(PREF_PLAYER_EMAIL);
		string playerData = firstName + "," + lastName + "," + phone + "," + email;
		return playerData;
	}
	
	// returns index of player data in prefs
	// returns 0 if not found
	public static int PlayerIndex(string playerData) {
		int keyIndex = 1;
		bool alreadyExists = false;
		while (PlayerPrefs.HasKey(PREF_PLAYER_DATA + keyIndex)) {
			string val = PlayerPrefs.GetString(PREF_PLAYER_DATA + keyIndex);
			if (val.StartsWith(playerData)) {
				alreadyExists = true;
				break;
			}

			++keyIndex;
		}
		
		if (alreadyExists) {
			keyIndex = 0;
		}
		
		return keyIndex;
	}
}
