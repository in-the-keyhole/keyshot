#pragma strict

var playerSpeedV : float = 10.0;
var playerSpeedH : float = 10.0;
var playerPosVMin : float = -4.5;
var playerPosVMax : float = 4.0;
var playerPosHMin : float = -6.0;
var playerPosHMax : float = 6.0;
var playerPosHStart:float = 0;
var playerPosVStart:float = -4.5;
var projectile:Transform;
var socketProjectile:Transform;
var shieldMesh:GameObject;
var shieldKey:KeyCode;

function Start () {
	ResetPosition();
}

function Update () {
	// calculate x and y movement based on time
	var transV = Input.GetAxis("Vertical") * playerSpeedV * Time.deltaTime;
	var transH = Input.GetAxis("Horizontal") * playerSpeedH * Time.deltaTime;

    transform.Translate (transH, transV, 0);

	// ensure movement does not go outside playfield
    transform.position.x = Mathf.Clamp(transform.position.x, playerPosHMin, playerPosHMax);
    transform.position.y = Mathf.Clamp(transform.position.y, playerPosVMin, playerPosVMax);

	if (Input.GetKeyDown(KeyCode.Escape)) {
		Application.LoadLevel("sceneScreenMainMenu");
	}

	if (Input.GetKeyDown(KeyCode.Space)) {
		Instantiate(projectile, socketProjectile.position, socketProjectile.rotation);
	}

	if (Input.GetKeyDown(shieldKey)) {
		if (scriptSceneManager2.shieldOff) {
			var clone = Instantiate(shieldMesh, transform.position, transform.rotation);
			clone.transform.parent = gameObject.transform;
			scriptSceneManager2.shieldOff = false;
		}
	}
}

function ResetPosition() {
	transform.position.x = playerPosHStart;
	transform.position.y = playerPosVStart;
}
