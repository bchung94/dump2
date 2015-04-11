using UnityEngine;
using System.Collections;

public class DeathScenario : MonoBehaviour {

	public bool dead;
	// Use this for initialization
	void Start () {
		dead = false;
	}

	void OnGUI() {
		//retry button!
		if (dead) {
			if (GUI.Button(new Rect(350, 250, 250, 100), "Retry?")) {
				Application.LoadLevel(1);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//Move player offscreen
		if ((transform.position.x < -12.0f)||(transform.position.y < -2.0f)) {
			transform.position = new Vector3(0,100.0f,0);
			dead = true;
		}
	}
}
