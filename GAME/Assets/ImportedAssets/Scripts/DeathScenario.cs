using UnityEngine;
using System.Collections;

public class DeathScenario : MonoBehaviour {

	private string p1name = "Player1(Clone)";
	private string p2name = "Player2(Clone)";
	public bool dead;
	private float deathCapX = -20.0f;
	private float deathCapY = -6.0f;
	private GameObject player1;
	private GameObject player2;
	private DeathScenario p1death;
	private DeathScenario p2death;

	// Use this for initialization
	void Start () {
		dead = false;
		//get both players death scripts
		player1 = GameObject.Find (p1name);
		p1death = player1.GetComponent<DeathScenario> ();
		player2 = GameObject.Find (p2name);
		if (player2 != null) {
			p2death = player2.GetComponent<DeathScenario> ();
		}

	}

	void OnGUI() {
		//retry button!
		if (p1death.dead && p2death.dead) {
			if (GUI.Button(new Rect(350, 250, 250, 100), "Retry?")) {
				player1.transform.position = new Vector3(-1f,0.5f,0);
				player2.transform.position = new Vector3(0,0.5f,0);
				dead = false;
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
		if (dead == true) {
			player2 = GameObject.Find (p2name);
			p2death = player2.GetComponent<DeathScenario> ();
		}
	}
}
