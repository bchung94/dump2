using UnityEngine;
using System.Collections;

public class P2move : MonoBehaviour {

	// for animation
	private Animator animatorControl;	// get animator from specified game object
	private int player = 1;

	//private Vector3 forward = new Vector3(0, 0, 5);
	private Vector3 side = new Vector3(5, 0, 0);
	private Vector3 up = new Vector3(0, 8, 0);
	private Vector3 extragrav = new Vector3(0,-10,0);
	public bool isgrounded;

	// set values
	private float jumpDelay = 0.05f;

	// Use this for initialization
	void Start () {
		// SET jump animtion
		SetPlayers setPlayer = gameObject.GetComponent<SetPlayers> ();
		animatorControl = setPlayer.getAnimator(player);
		animatorControl.SetBool("Jump", false);
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			isgrounded = true;	
			animatorControl.SetBool("Jump", false);
		}
	}
	
	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			isgrounded = false;
		}
	}

	IEnumerator Jump() {
		yield return new WaitForSeconds (jumpDelay);
		rigidbody.velocity = up;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.MovePosition(rigidbody.position + (-side) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidbody.MovePosition(rigidbody.position + side * Time.deltaTime);
		}
		if ((Input.GetKey (KeyCode.UpArrow)) && (isgrounded == true)) {
			animatorControl.SetTrigger("Jump");
			StartCoroutine(Jump ());
		}
		if (isgrounded == false) {
			rigidbody.AddForce(extragrav);
		}
		rigidbody.transform.rotation = Quaternion.identity;
	}

}
