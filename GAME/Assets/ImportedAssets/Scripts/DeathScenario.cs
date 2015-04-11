using UnityEngine;
using System.Collections;

public class DeathScenario : MonoBehaviour {

	public bool dead;
	private float deathCapX = -20.0f;
	private float deathCapY = -6.0f;

	// Use this for initialization
	void Start () {
		dead = false;
	}

	void OnGUI() {
		//retry button!
		if (dead) {
			if (GUI.Button(new Rect(350, 250, 250, 100), "Retry?")) {
				Application.LoadLevel(2);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//Move player offscreen
		if ((transform.position.x < deathCapX)||(transform.position.y < deathCapY)) {
			transform.position = new Vector3(0,100.0f,0);
			dead = true;
		}
	}
}
