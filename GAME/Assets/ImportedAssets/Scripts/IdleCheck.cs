using UnityEngine;
using System.Collections;

public class IdleCheck : MonoBehaviour {

	// Animation
	private Animator animatorControl;
	private int player = 1;

	private RaycastHit hit;
	public string collide;
	
	// Use this for initialization
	void Start () {
		// SET Idle Animation
		SetPlayers setPlayer = gameObject.GetComponent<SetPlayers> ();
		animatorControl = setPlayer.getAnimator(player);
		//animatorControl.SetBool("Stop", false);
	}
	
	// Update is called once per frame
	void Update () {
		//checks for forward collision and enters idle animation
		Vector3 fwd = transform.TransformDirection (Vector3.back);
		Debug.DrawRay(transform.position, fwd, Color.red);
		if(Physics.Raycast(transform.position, fwd, out hit, 1.0f)) {
			collide = hit.collider.gameObject.name;
			if (collide == "Player2" || collide == "Cube") {
				//Idle animation
				animatorControl.SetBool("Stop", true);
				Debug.Log ("STopped");
			} else
			{
				animatorControl.SetBool("Stop", false);
			}
		}
	}
}
