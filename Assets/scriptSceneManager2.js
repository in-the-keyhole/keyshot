#pragma strict

import System.Collections.Generic;

static var score:int = 0;
static var lives:int = 3;
static var shieldStrength:int = 3;
static var shieldOff:boolean = true;
static var winScore:int = 10000;
static var timeToPlay:float = 30.0;
static var gameTime:float = timeToPlay;

static var PREF_PLAYER_FIRST_NAME:String = "PLAYER_FIRST_NAME";
static var PREF_PLAYER_LAST_NAME:String  = "PLAYER_LAST_NAME";
static var PREF_PLAYER_PHONE:String      = "PLAYER_PHONE";
static var PREF_PLAYER_EMAIL:String      = "PLAYER_EMAIL";
static var PREF_DOES_PLAYER_EXIST:String = "DOES_PLAYER_EXIST";
static var PREF_SCORE:String             = "SCORE";
static var PREF_PLAYER_DATA:String       = "playerData";

static var TAG_PLAYER:String             = "Player";
static var TAG_ASTROID:String            = "Astroid";
static var TAG_SHIELD:String             = "Shield";

function Start () {
	//resetHighScores();
	score = 0;
	lives = 3;
	shieldStrength = 3;
	shieldOff = true;
	gameTime = timeToPlay;
	InvokeRepeating("CountDown", 1.0, 1.0);
}

function Update () {
	if (lives <= 0) {
		saveHighScores();
	}
}

static function AddScore(points:int) {
	score += points;
}

function CountDown() {
	gameTime -= 1.0;
	if (gameTime <= 0.0) {
		saveHighScores();
	}
}

function OnGUI() {
    GUI.Label(Rect(10, 10, 100, 35), "Time   : " + gameTime);	 
	GUI.Label(Rect(10, 25, 100, 20), "Score  : " + score);
	GUI.Label(Rect(10, 40, 100, 35), "Lives  : " + lives);
	if (!shieldOff) {
		GUI.Label(Rect(10, 55, 100, 50), "Shield : " + shieldStrength);	 
	}
}

function saveHighScores() {
	CancelInvoke("CountDown");
	PlayerPrefs.SetInt(PREF_SCORE, score);

	// this data is how we form the key to search for the player
	var playerData:String = MakePlayerKey();
	var keyIndex:int = PlayerIndex(playerData);

	if (keyIndex > 0) {
		var maxPlayerIndex:int = MaxPlayerIndex();
		var highScores:List.<KeyValuePair.<int, String> > = new List.<KeyValuePair.<int, String> >();

		// read in scores & names
    	for (var i:int = 1; i <= maxPlayerIndex; i++) {
			var currentData:String = PlayerPrefs.GetString(PREF_PLAYER_DATA + i);
			if (currentData.Length > 0) {
				var currentScore:int = int.Parse(currentData.Substring(currentData.LastIndexOf(",") + 1));
				var highScore:KeyValuePair.<int, String> = new KeyValuePair.<int, String>(currentScore, currentData);
				highScores.Add(highScore);
			}
		}

		// add current score in sorted position
		playerData += "," + score;
		var newScore:KeyValuePair.<int, String> = new KeyValuePair.<int, String>(score, playerData);
		var playerInserted:boolean = false;
		for (i = 0; i < highScores.Count; i++) {
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
    	for (i = 0; i < highScores.Count; i++) {
    		PlayerPrefs.SetString(PREF_PLAYER_DATA + (i + 1), highScores[i].Value);
    	}

		PlayerPrefs.Save();
	} else {
		PlayerPrefs.SetString(PREF_DOES_PLAYER_EXIST, "TRUE");
	}

	Application.LoadLevel("sceneScreenWin");
}

static function MakePlayerKey():String {
	// this data is how we form the key to search for the player
	var firstName:String = PlayerPrefs.GetString(PREF_PLAYER_FIRST_NAME);
	var lastName:String = PlayerPrefs.GetString(PREF_PLAYER_LAST_NAME);
	var phone:String = PlayerPrefs.GetString(PREF_PLAYER_PHONE);
	var email:String = PlayerPrefs.GetString(PREF_PLAYER_EMAIL);
	var playerData:String = firstName + "," + lastName + "," + phone + "," + email;
	return playerData;
}

// returns the next index after the last player
static function MaxPlayerIndex():int {
	var keyIndex:int = 1;
	while (PlayerPrefs.HasKey(PREF_PLAYER_DATA + keyIndex)) {
		++keyIndex;
	}

	return keyIndex;
}

// returns index of player data in prefs
// returns 0 if not found
static function PlayerIndex(playerData:String):int {
	var keyIndex:int = 1;
	var alreadyExists:boolean = false;
	while (PlayerPrefs.HasKey(PREF_PLAYER_DATA + keyIndex)) {
		var val:String = PlayerPrefs.GetString(PREF_PLAYER_DATA + keyIndex);
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
