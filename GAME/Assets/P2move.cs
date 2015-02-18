using UnityEngine;
using System.Collections;

public class P2move : MonoBehaviour {

	private Vector3 forward = new Vector3(0, 0, 5);
	private Vector3 side = new Vector3(5, 0, 0);
	private Vector3 up = new Vector3(0, 6, 0);
	public bool isgrounded;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			isgrounded = true;
		}
	}
	
	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			isgrounded = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.MovePosition(rigidbody.position + (-side) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidbody.MovePosition(rigidbody.position + side * Time.deltaTime);
		}
		if ((Input.GetKey (KeyCode.RightShift))&&(isgrounded == true)) {
			//rigidbody.AddForce (0, speed*2, 0);
			rigidbody.velocity = up;
		}
		rigidbody.transform.rotation = Quaternion.identity;
	}

}
