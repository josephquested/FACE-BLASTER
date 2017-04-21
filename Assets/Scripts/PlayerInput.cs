using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// SYSTEM //

	ActorSM actorSM;

	void Start ()
	{
		actorSM = GetComponent<ActorSM>();
	}

	void FixedUpdate ()
	{
		UpdateAxisRaw();
	}

	void Update ()
	{
		UpdateJump();
	}

	// MOVEMENT //

	void UpdateAxisRaw ()
	{
		actorSM.ReceiveAxisRaw(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	// JUMP //

	void UpdateJump ()
	{
		actorSM.ReceiveJump(Input.GetButton("Jump"), Input.GetButtonDown("Jump"));
	}
}
