using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float speed;

	public float fastSpeed = 0.1f;
	public float normalSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		speed = normalSpeed;
	}

	// Update is called once per frame
	void Update () {
		float offset = Time.time * speed;
		renderer.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
