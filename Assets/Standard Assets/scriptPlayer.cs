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

	private bool useKeyboard = true;
	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("keyshot.input")) {
			string pref = PlayerPrefs.GetString("keyshot.input");
			if (pref == "touchscreen") {
				useKeyboard = false;
			} else {
				useKeyboard = true;
			}
		} else if (SystemInfo.supportsAccelerometer) {
			useKeyboard = false;
		}

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		ResetPosition();
	}
	
	// Update is called once per frame
	void Update () {		
		float transH = 0;
		float transV = 0;
		Vector3 dir = Vector3.zero;

		if (!useKeyboard) {
			dir.x = Input.acceleration.x;
			dir.y = Input.acceleration.y;
			transH = dir.x * (playerSpeedH + 10.0f) * Time.deltaTime;
			transV = dir.y * (playerSpeedV + 10.0f) * Time.deltaTime;
		} else {
			// calculate x and y movement based on time
			transH = Input.GetAxis("Horizontal") * playerSpeedH * Time.deltaTime;
			transV = Input.GetAxis("Vertical") * playerSpeedV * Time.deltaTime;
		}

	    transform.Translate(transH, transV, 0);

		float z = transform.position.z;
		
		// ensure movement does not go outside playfield
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, playerPosHMin, playerPosHMax),
	                                     Mathf.Clamp(transform.position.y, playerPosVMin, playerPosVMax),
										 z);
	
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("sceneScreenMainMenu");
		}

		bool space = false;
		if (scriptSceneManager.score >= scriptSceneManager.bonusScore) {
			if (Input.GetKey(KeyCode.Space)) {
				space = true;
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
				space = true;
			}
		}
		
		bool touched = false;
		if (!useKeyboard) {
			if (scriptSceneManager.score >= scriptSceneManager.bonusScore) {
				foreach (Touch touch in Input.touches) {
					if (Input.touchCount == 1 && touch.phase == TouchPhase.Stationary) {
						touched = true;
						break;
					}
				}
			} else {
				foreach (Touch touch in Input.touches) {
					if (Input.touchCount == 1 && touch.phase == TouchPhase.Began) {
						touched = true;
						break;
					}
				}
			}
		}
		
		if (space || touched) {
			Instantiate(projectile, socketProjectile.position, socketProjectile.rotation);
		}
	
		if (Input.GetKeyDown(shieldKey) || Input.touchCount == 2) {
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
