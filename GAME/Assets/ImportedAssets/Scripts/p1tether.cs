using UnityEngine;
using System.Collections;

public class P1tether : MonoBehaviour {

	private GameObject player2;
	private GameObject background;
	private BackgroundScroll scroll;
	private float Xpos, Ypos;
	public float distX, distY;
	public float speed, speed2;
	public bool checktether;
	public bool tethered;

	// Use this for initialization
	void Start () {
		speed = 0;
		speed2 = 0;
		checktether = false;
		tethered = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//input timer for tether button
		player2 = GameObject.Find ("Player2");
		if ((Input.GetKey (KeyCode.E))&&(player2.transform.position.x > transform.position.x)) {
					distX = (Mathf.Abs (player2.transform.position.x - transform.position.x)) * 1.5f;
					distY = (Mathf.Abs (player2.transform.position.y - transform.position.y)) * 1.5f;
					Xpos = transform.position.x;
					Ypos = transform.position.y;
					checktether = true;
					tethered = true;
				}

		if (checktether == true) {

			background = GameObject.Find("Backdrop1");
			BackgroundScroll bgScroll = background.GetComponent<BackgroundScroll>();

			float speedIncrease = 0.01f;

			if ((Xpos + distX) >= 4) {
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
					bgScroll.speed = bgScroll.fastSpeed;
				}
			}
			else {
				if(Mathf.Abs(transform.position.x - Xpos) < distX) {
					transform.position += new Vector3 (speed, 0, 0);
					speed += speedIncrease;
				}
			}
			if(Mathf.Abs(transform.position.y - Ypos) < distY) {
				transform.position += new Vector3 (0, speed2, 0);
				speed2 += speedIncrease;
			}
			if ((Mathf.Abs(transform.position.x - Xpos) >= distX)||(transform.position.x - player2.transform.position.x >= (distX/3))) {
				speed = 0;
				checktether = false;
				tethered = false;
				bgScroll.speed = bgScroll.normalSpeed;
				//undo boost to foreground speed for all generated obstacles
				foreach(GameObject check in GameObject.FindGameObjectsWithTag ("Floor")) {
					DestroySet destroySet = check.GetComponent<DestroySet> ();
					if (destroySet != null) {
						destroySet.speed = destroySet.normalSpeed;
					}
				}
			}
			if (Mathf.Abs(transform.position.y - Ypos) >= distY) {
				speed2 = 0;
			}
				}
	}
}
