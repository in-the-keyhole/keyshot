using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour {
	public float playerSpeedV    = 10.0f;
	public float playerSpeedH    = 10.0f;
	public float playerPosVMin   = -4.5f;
	public float playerPosVMax   = 4.0f;
	public float playerPosHMin   = -6.0f;
	public float playerPosHMax   = 6.0f;
	public float playerPosHStart = 0;
	public float playerPosVStart = -4.5f;
	public Transform projectile;
	public Transform socketProjectile;
	public GameObject shieldMesh;
	public KeyCode shieldKey;

	// Use this for initialization
	void Start () {
		ResetPosition();
	}
	
	// Update is called once per frame
	void Update () {
		// calculate x and y movement based on time
		float transV = Input.GetAxis("Vertical") * playerSpeedV * Time.deltaTime;
		float transH = Input.GetAxis("Horizontal") * playerSpeedH * Time.deltaTime;
	
	    transform.Translate (transH, transV, 0);

		float z = transform.position.z;
		
		// ensure movement does not go outside playfield
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, playerPosHMin, playerPosHMax),
	                                     Mathf.Clamp(transform.position.y, playerPosVMin, playerPosVMax),
										 z);
	
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("sceneScreenMainMenu");
		}
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(projectile, socketProjectile.position, socketProjectile.rotation);
		}
	
		if (Input.GetKeyDown(shieldKey)) {
			if (scriptSceneManager.shieldOff) {
				GameObject clone = Instantiate(shieldMesh, transform.position, transform.rotation) as GameObject;
				clone.transform.parent = this.transform;
				scriptSceneManager.shieldOff = false;
			}
		}
	}

	public void ResetPosition() {
		float z = transform.position.z;
		this.transform.position = new Vector3(playerPosHStart, playerPosVStart, z);
	}
}
