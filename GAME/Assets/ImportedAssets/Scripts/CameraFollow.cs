using UnityEngine;
using System.Collections;

public class CameraFollow: MonoBehaviour {

	private GameObject player1;
	private float height;

	private float maxHeight = -2.0f;
	private float defaultX;
	private float defaultY;
	private float defaultZ;

	// Use this for initialization
	void Start () {
		defaultX = Camera.main.gameObject.transform.position.x;
		defaultY = Camera.main.gameObject.transform.position.y;
		defaultZ = Camera.main.gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		player1 = GameObject.Find ("Player1");
		height = (float)player1.transform.position.y;
		if (height >= maxHeight) {
			this.gameObject.transform.position = new Vector3(defaultX, height, defaultZ);
		}
		else {
			this.gameObject.transform.position = new Vector3(defaultX, defaultY, defaultZ);
		}
	}
}
