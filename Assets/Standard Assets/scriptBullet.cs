using UnityEngine;
using System.Collections;

public class scriptBullet : MonoBehaviour {
	public float bulletSpeed = 15.0f;
	public float bulletMaxV = 10.0f;
	public GameObject explosion;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,bulletSpeed * Time.deltaTime,0);
		if (transform.position.y >= bulletMaxV) {	
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals(scriptSceneManager.TAG_ASTROID)) {
			// print("Astroid " + other.gameObject.name + " hit!");
			scriptAstroid astroidScript = other.GetComponent<scriptAstroid>();
			astroidScript.ResetPosition();
			if (explosion) {
				GameObject clone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
				Destroy(clone, 2);
			}
	
			if (other.gameObject.audio.clip) {
				other.gameObject.audio.Play();
			}
	
			Destroy(gameObject);
	
			scriptSceneManager.AddScore(500);
		}
	}
}
