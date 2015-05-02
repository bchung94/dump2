using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathScenario : MonoBehaviour {
	
	public bool dead = false;
	private float deathCapX = -20.0f;
	private float deathCapY = -6.0f;

	GameObject replayButton;
	GameObject homeButton;
	GameObject jumpButton;
	GameObject pullButton;

	// Use this for initialization
	void Start () {
		dead = false;

		// get buttons to update 
		replayButton = GameObject.Find ("ReplayButton");
		homeButton = GameObject.Find ("HomeButton");
		jumpButton = GameObject.Find ("Jump Button");
		pullButton = GameObject.Find ("Pull Button");
		replayButton.SetActive(false);
		homeButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//Move player offscreen
		if ((transform.position.x < deathCapX)||(transform.position.y < deathCapY)) {
			transform.position = new Vector3(0,100.0f,0);
			dead = true;
		}

		if (dead == true) {
			pullButton.GetComponent<Button> ().interactable = false;
			jumpButton.GetComponent<Button> ().interactable = false;
			replayButton.SetActive (true);
			homeButton.SetActive (true);
		}
	}
}
