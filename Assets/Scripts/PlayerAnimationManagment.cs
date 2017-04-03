using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManagment : MonoBehaviour {

	private Animator animator;
	private InputState inputstate;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		inputstate = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		var running = true;

		if (inputstate.absVelX > 0 && inputstate.absVelY < inputstate.standingThreshold)
			running = false;

		animator.SetBool ("Running", running);
	}
}
