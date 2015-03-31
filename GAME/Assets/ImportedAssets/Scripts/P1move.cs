using UnityEngine;
using System.Collections;

public class P1move : MonoBehaviour {

	// initialize values
	private Animator animator;
	public bool isgrounded;
	private RaycastHit hit;
	public string collide;

	// set values
	//private Vector3 forward = new Vector3(0, 0, 5);
	private Vector3 side = new Vector3(5, 0, 0);	// movement speed
	private Vector3 up = new Vector3(0, 8, 0);	// jump height
	private Vector3 extragrav = new Vector3(0, -13, 0);

	private float speedBumpDuration = 0.5f;
	private float blockDuration = 4.0f;
	private float jumpDelay = 0.05f;

	// Use this for initialization	
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("Jump", false);
	}

	//Speed boost
	IEnumerator Speedbump() {

		// initiate values
		GameObject background;
		GameObject generator;

		background = GameObject.Find ("Backdrop1");
		generator = GameObject.Find ("Floor");

		BackgroundScroll bgScroll = background.GetComponent<BackgroundScroll> ();
		GenerateLevelSets genLevel = generator.GetComponent<GenerateLevelSets> ();

		// Boost foreground speed for all generated obstacles
		foreach(GameObject check in GameObject.FindGameObjectsWithTag ("Floor")) {
			DestroySet destroySet = check.GetComponent<DestroySet>();
			if (destroySet != null) {
				destroySet.speed = destroySet.fastSpeed;
			}
		}

		// Boost gen object speed while using powerup
		genLevel.speed = genLevel.fastSpeed;
		
		// Boost background speed
		bgScroll.speed = bgScroll.fastSpeed;

		// Duration of boost
		yield return new WaitForSeconds (speedBumpDuration);

		// Boost foreground speed for all generated obstacles
		foreach(GameObject check in GameObject.FindGameObjectsWithTag ("Floor")) {
			DestroySet destroySet = check.GetComponent<DestroySet>();
			if (destroySet != null) {
				destroySet.speed = destroySet.normalSpeed;
			}
		}
		// Undo boost to gen object speed
		genLevel.speed = genLevel.normalSpeed;

		// Undo boosted speed for background
		bgScroll.speed = bgScroll.normalSpeed;
	}

	//block powerup function
	IEnumerator Block() {
		GameObject player1, player2, cube;
		cube = GameObject.Find("Cube");
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");

		//if either player is being tethered then let pass
		if ((player1.GetComponent<P1tether>().tethered == true) || (player2.GetComponent<P2tether>().tethered == true)) {
			cube.layer = 9;
		}

		// wait duration
		yield return new WaitForSeconds (blockDuration);
		cube.layer = 8;
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			animator.SetBool("Jump", false);
		}
		//check for collision with block powerup
		if (collision.gameObject.name == "Cube") {
			StartCoroutine(Block ());
		}
	}

	void OnTriggerEnter() {
			//If player collides with powerup
			StartCoroutine(Speedbump());
	}

	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			isgrounded = false;
		}
	}

	IEnumerator Jump() {
		//Add jump delay and then jump up
		yield return new WaitForSeconds (jumpDelay);
		rigidbody.velocity = up;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 downray = transform.TransformDirection (Vector3.down);

		//temporary forward and backwards movement
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.MovePosition(rigidbody.position + (-side) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.MovePosition(rigidbody.position + side * Time.deltaTime);
		}

		//cast ray to check if REALLY grounded
		if (Physics.Raycast(transform.position, downray, out hit, 1)) {
			collide = hit.collider.gameObject.name;
			Debug.DrawRay(transform.position, downray, Color.green);
			//make exceptions if grounded against powerups or other players
			if (collide == "Player2" || collide == "Sphere") {
				isgrounded = false;
			}
			else {isgrounded = true;}
		}
		else { isgrounded = false;}

		//jump function
		if ((Input.GetKey (KeyCode.Space))&&(isgrounded == true)) {
			animator.SetBool("Jump", isgrounded);
			StartCoroutine(Jump ());
		}
		if (isgrounded == false) {
			rigidbody.AddForce(extragrav);
		}

		//make sure model is facing correct direction
		rigidbody.transform.rotation = Quaternion.identity;
		rigidbody.transform.Rotate (0, 270, 0);
	}
}
