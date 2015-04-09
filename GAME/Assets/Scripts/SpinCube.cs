using UnityEngine;
using System.Collections;

public class SpinCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xspeed = 50.0f;
		float yspeed = 25.0f;
		float zspeed = 0.0f;
		transform.Rotate (new Vector3 (xspeed, yspeed, zspeed)*Time.deltaTime);
	}
}
