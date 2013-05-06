using UnityEngine;
using System.Collections;

public class scriptShield : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (scriptSceneManager.shieldStrength <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals(scriptSceneManager.TAG_ASTROID)) {
			--scriptSceneManager.shieldStrength;
		}
	}
}
