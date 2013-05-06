#pragma strict

var astroidSpeed:float = 6.0;
var astroidMinV:float = -10.0;
var playerResetWaitTime = 0.5;
var explosion:GameObject;

function Update () {
	transform.Translate(Vector3.down * astroidSpeed * Time.deltaTime);
	if (transform.position.y <= astroidMinV) {
		ResetPosition();
	}
}

function OnTriggerEnter(other:Collider) {
	if (other.gameObject.tag == scriptSceneManager2.TAG_PLAYER) {
		var playerScript = other.GetComponent(scriptPlayer2);
		--scriptSceneManager2.lives;
		if (explosion) {
			var clone:GameObject = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(clone,2);
		}

		if (other.gameObject.audio.clip) {
			other.gameObject.audio.Play();
		}

		other.renderer.enabled = false;
		yield WaitForSeconds(playerResetWaitTime);

		playerScript.ResetPosition();
		other.renderer.enabled = true;

		ResetPosition();
	}

	if (other.gameObject.tag == scriptSceneManager2.TAG_SHIELD) {
		if (other.gameObject.audio.clip) {
			other.gameObject.audio.Play();
		}

		if (explosion) {
			var clone2:GameObject = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(clone2,2);
		}

		ResetPosition();
	}
}

function ResetPosition() {
	transform.position.x = Random.Range(-6.0, 6.0);
	transform.position.y = 8.0;
}