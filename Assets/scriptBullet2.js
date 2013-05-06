#pragma strict

var bulletSpeed:float = 15.0;
var bulletMaxV:float = 10.0;
var explosion:GameObject;

function Update () {
	transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
	if (transform.position.y >= bulletMaxV) {	
		Destroy(gameObject);
	}
}

function OnTriggerEnter(other:Collider) {
	if (other.gameObject.tag == scriptSceneManager2.TAG_ASTROID) {
		// print("Astroid " + other.gameObject.name + " hit!");
		var astroidScript = other.GetComponent(scriptAstroid2);
		astroidScript.ResetPosition();
		if (explosion) {
			var clone:GameObject = Instantiate(explosion, transform.position, transform.rotation);
			Destroy(clone, 2);
		}

		if (other.gameObject.audio.clip) {
			other.gameObject.audio.Play();
		}

		Destroy(gameObject);

		scriptSceneManager2.AddScore(500);
	}
}
