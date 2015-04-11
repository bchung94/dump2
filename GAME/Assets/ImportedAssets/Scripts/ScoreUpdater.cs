using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

	public float score;
	// Use this for initialization
	void Start () {
		score = 0;
	}

	void OnGUI()
	{
		//show score
		GUI.Button (new Rect (10, 10, 110, 40), "Score: " + score);
	}

	// Update is called once per frame
	void Update () {
		GameObject playerdead = GameObject.Find ("Player1");
		DeathScenario death = playerdead.GetComponent<DeathScenario> ();
		//if player is dead
		if (death.dead == false) {
			//stop updating score
			score += 1.0f;

			//update leaderboard
		}
	}
}
