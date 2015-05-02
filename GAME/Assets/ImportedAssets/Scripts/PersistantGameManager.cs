using UnityEngine;
using System.Collections;

public class PersistantGameManager : MonoBehaviour {
	
	public string characterSelectedString;
	public string allyCharacterString;
	private GameObject[] players;

	// Use this for initialization
	void Start () {
	}

	public void characterButton (string character) {
		Debug.Log (character);
		characterSelectedString = character;
	}

	// Make this game object and all its transform children
	// survive when loading a new scene.
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update () {
		// find enemy character name
		players = GameObject.FindGameObjectsWithTag ("Player");
		if (players.Length == 2) {
			foreach (GameObject player in players){
				if (player.name != characterSelectedString+"_Prefab(Clone)")
				{
					allyCharacterString = player.name;
				}
			}
		}

	}
}
