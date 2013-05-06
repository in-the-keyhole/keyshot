#pragma strict

function Update() {
	if (scriptSceneManager2.shieldStrength <= 0) {
		Destroy(gameObject);
	}
}

function OnTriggerEnter(other:Collider) {
	if (other.tag == scriptSceneManager2.TAG_ASTROID) {
		--scriptSceneManager2.shieldStrength;
	}
}