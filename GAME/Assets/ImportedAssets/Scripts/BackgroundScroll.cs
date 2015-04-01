using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float offset = Time.time * speed;
		renderer.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
