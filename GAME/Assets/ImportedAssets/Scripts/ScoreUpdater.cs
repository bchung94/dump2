using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	private Text ScoreText;
	public float score;

	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text> ();
		score = 0;
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
		ScoreText.text = "Score: " + score;
	}
}
