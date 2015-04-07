using UnityEngine;
using System.Collections;

public class IdleCheck : MonoBehaviour {

	// Animation
	private Animator animatorControl;

	private RaycastHit hit;
	public string collide;
	
	// Use this for initialization
	void Start () {
		// SET Idle Animation
		animatorControl = GetComponentInChildren<Animator>();
		animatorControl.SetBool("Stop", false);
	}
	
	// Update is called once per frame
	void Update () {
		//checks for forward collision and enters idle animation
		Vector3 fwd = transform.TransformDirection (new Vector3(1.0f,0,0));
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
