using UnityEngine;
using System.Collections;

public class setMove : MonoBehaviour {

	private GameObject player1;
	private GameObject speedboost;
	private GameObject bg;
	private float speedup;
	public bool check;
	public bool check2;
	private bool hit;
	// Use this for initialization
	void Start () {
		speedup = -0.05f;
		hit = false;
	}

	IEnumerator Speedup() {
		bg = GameObject.Find ("Backdrop1");
		bg.GetComponent<backgroundscroll> ().speed = 1.0f;
		speedup = -0.15f;
		yield return new WaitForSeconds (4.0f);
		bg.GetComponent<backgroundscroll> ().speed = 0.5f;
		speedup = -0.05f;
		hit = false;
	}

	// Update is called once per frame
	void Update () {
		player1 = GameObject.Find ("Player1");
		speedboost = GameObject.Find ("Sphere");
		if (player1.transform.position.y >= (speedboost.transform.position.y-1)) {
			if (player1.transform.position.y <= (speedboost.transform.position.y+1)) {
				check = true;
			}
			else {
				check = false;
			}
		}
		else {
			check = false;
		}
		if ((player1.transform.position.x >= (speedboost.transform.position.x - 0.1f)) && (player1.transform.position.x <= (speedboost.transform.position.x + 0.1f))) {
			check2 = true;
		}
		else {
			check2 = false;
		}
		if ((check2) && (check)) {
			hit = true;
			StartCoroutine(Speedup ());
		}
		transform.position += new Vector3 (speedup, 0, 0);
		//speed -= 0.1f;
			if (transform.position.x <= -15.0f)
			{
			transform.position += new Vector3(35.0f,0,0);
			}

	}
}
