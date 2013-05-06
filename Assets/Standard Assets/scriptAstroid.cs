using UnityEngine;
using System.Collections;

public class scriptAstroid : MonoBehaviour {
	public float astroidSpeed = 6.0f;
	public float astroidMinV = -10.0f;
	public float playerResetWaitTime = 0.5f;
	public GameObject explosion;
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.down * astroidSpeed * Time.deltaTime);
		if (this.transform.position.y <= astroidMinV) {
			ResetPosition();
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == scriptSceneManager.TAG_PLAYER) {
			scriptPlayer playerScript = other.GetComponent<scriptPlayer>();
			--scriptSceneManager.lives;
			if (explosion) {
				GameObject clone = Instantiate(explosion, other.transform.position, other.transform.rotation) as GameObject;
				Destroy(clone, 2);
			}
	
			if (other.gameObject.audio.clip) {
				other.gameObject.audio.Play();
			}
	
			other.renderer.enabled = false;
			WaitTime(playerResetWaitTime);
	
			playerScript.ResetPosition();
			other.renderer.enabled = true;
	
			ResetPosition();
		}
	
		if (other.gameObject.tag == scriptSceneManager.TAG_SHIELD) {
			if (other.gameObject.audio.clip) {
				other.gameObject.audio.Play();
			}
	
			if (explosion) {
				GameObject clone2 = Instantiate(explosion, other.transform.position, other.transform.rotation) as GameObject;
				Destroy(clone2, 2);
			}
	
			ResetPosition();
		}
	}
	
	public void ResetPosition() {
		float z = this.transform.position.z;
		this.transform.position = new Vector3(Random.Range (-6.0f, 6.0f), 8.0f, z);
	}

	IEnumerator WaitTime(float waitTime) {
		yield return new WaitForSeconds(waitTime);
	}
}
