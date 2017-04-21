using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// SYSTEM //

	ActorController actor;

	void Start ()
	{
		actor = GetComponent<ActorController>();
	}

	void FixedUpdate ()
	{
		UpdateAxis();
	}

	void Update ()
	{
		UpdateJump();
	}

	// MOVEMENT //

	void UpdateAxis ()
	{
		actor.ReceiveAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	// JUMP //

	void UpdateJump ()
	{
		actor.ReceiveJump(Input.GetButton("Jump"), Input.GetButtonDown("Jump"));
	}
}
