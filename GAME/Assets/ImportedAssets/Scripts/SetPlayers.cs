using UnityEngine;
using System.Collections;

public class SetPlayers : MonoBehaviour {
	
	// for animation
	public GameObject playerObject;
	private Animator animator;	// get animator from specified game object
	
	
	// Use this for initialization
	void Start () {
		animator = playerObject.GetComponent<Animator>();
	}

	public Animator getAnimator (int Player)
	{
		return animator;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
