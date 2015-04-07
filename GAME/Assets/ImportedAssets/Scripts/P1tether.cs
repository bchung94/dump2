using UnityEngine;
using System.Collections;

public class P1tether : MonoBehaviour {

	// for animation
	private Animator animatorControl;

	// intialize
	private GameObject player2;
	private GameObject background;
	private BackgroundScroll scroll;
	private float Xpos, Ypos;
	public float distX, distY;
	public float speed, speed2;
	public bool checktether;
	public bool inFront;

	// Use this for initialization
	void Start () {
		speed = 0;
		speed2 = 0;
		checktether = false;

		// SET tether animation
		animatorControl = GetComponentInChildren<Animator>();
		animatorControl.SetBool("Pulled", checktether);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//find player2 and lock location for future reference
		player2 = GameObject.Find ("Player2");
		if ((Input.GetKey (KeyCode.E))) {
					
					//set total future distance to be travelled
					distX = (Mathf.Abs (player2.transform.position.x - transform.position.x)) * 1.5f;
					distY = (Mathf.Abs (player2.transform.position.y - transform.position.y)) * 1.5f;
					
					//save initial coordinates
					Xpos = transform.position.x;
					Ypos = transform.position.y;
					
					//check if player2 is in front or behind
					if (player2.transform.position.x > transform.position.x) {
						inFront = true;
					}
					else {
						inFront = false;
					}
					//begin tether!
					checktether = true;
				}

		// tether animation
		animatorControl.SetBool("Pulled", checktether);
		animatorControl.SetBool("IsFront", inFront);

		if (checktether == true) {

			//speed up background speed while tether animation is running
			background = GameObject.Find("Background");
			BackgroundScroll bgScroll = background.GetComponent<BackgroundScroll>();

			float speedIncrease = 0.01f;

			if (inFront == true) {
				//if the distance travelled puts player1 past 2/3rds of the screen
				if ((Xpos + distX) >= 4) {
					//change tether mechanic to push player2 back so player1 stays
					//within first 2/3rds of screen
					if(Mathf.Abs(transform.position.x - Xpos) < (distX/2)) {
						transform.position += new Vector3 (speed, 0, 0);
						player2.transform.position -= new Vector3 (speed, 0, 0);
						speed += speedIncrease;

						//Boost foreground speed for all generated obstacles
						foreach(GameObject check in GameObject.FindGameObjectsWithTag ("Floor")) {
							DestroySet destroySet = check.GetComponent<DestroySet> ();
							if (destroySet != null) {
								destroySet.speed = destroySet.fastSpeed;
							}
						}
						bgScroll.speed = bgScroll.normalSpeed;
					}
				}
				//normal tether that just pulls player1 forward
				else {
					if(Mathf.Abs(transform.position.x - Xpos) < distX) {
						transform.position += new Vector3 (speed, 0, 0);
						speed += speedIncrease;
					}
				}
			}
			else {
				if(Mathf.Abs(transform.position.x - Xpos) < distX) {
					transform.position -= new Vector3 (speed, 0, 0);
					speed += speedIncrease;
				}
			}
			//tether upwards as well depending on difference in height
			if(Mathf.Abs(transform.position.y - Ypos) < distY) {
				transform.position += new Vector3 (0, speed2, 0);
				speed2 += speedIncrease;
			}

			//reset variables once tether distance is travelled
			if ((Mathf.Abs(transform.position.x - Xpos) >= distX)) {
				speed = 0;
				checktether = false;
				bgScroll.speed = bgScroll.normalSpeed;
				//undo boost to foreground speed for all generated obstacles
				foreach(GameObject check in GameObject.FindGameObjectsWithTag ("Floor")) {
					DestroySet destroySet = check.GetComponent<DestroySet> ();
					if (destroySet != null) {
						destroySet.speed = destroySet.normalSpeed;
					}
				}
			}

			//stop tethering upwards once max height is reached
			if (Mathf.Abs(transform.position.y - Ypos) >= distY) {
				speed2 = 0;
			}
				}
	}
}
