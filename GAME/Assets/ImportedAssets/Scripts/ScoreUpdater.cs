﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	private PersistantGameManager gameManager;
	private string characterString;
	private GameObject player;
	public string playername = "Player1(Clone)";
	public int score;
	private Text ScoreText;
	public int Highscore;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameController").GetComponent<PersistantGameManager>();
		characterString = gameManager.thisPlayer;
		player = GameObject.Find (characterString);
		if(PhotonView.Get(player).isMine) {
			playername = gameManager.thisPlayer;
		}
		else {
			playername = gameManager.otherPlayer;
		}
		ScoreText = GetComponent<Text> ();
		Highscore = PlayerPrefs.GetInt ("High Score");
		score = 0;
	}
	
	void OnGUI()
	{
		//show score
		GUI.Button (new Rect (10, 10, 110, 80), "High Score: " + Highscore + "\n" + "Score: " + score);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject playerdead = GameObject.Find (playername);
		DeathScenario death = playerdead.GetComponent<DeathScenario> ();
		//if player is alive
		if (death.dead == false) {
			//update highscore if score is higher
			if (score > Highscore) {
				Highscore = score;
			}
			//updating score
			score += 1;
		}
		else {
			//update leaderboard
			PlayerPrefs.SetInt("High Score", Highscore);
		}
		ScoreText.text = "Score: " + score;
	}
}