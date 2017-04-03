using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float jumpSpeed = 240f;
	public float forwardmovemant = 20f;

	private Rigidbody2D body2d;
	private InputState inputState;

	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inputState.actionButton) {
			if (inputState.actionButton) {
				body2d.velocity = new Vector2 (transform.position.x < 0 ? forwardmovemant : 0 , jumpSpeed);
			}
		}
	}
}
