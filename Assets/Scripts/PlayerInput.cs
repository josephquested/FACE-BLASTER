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
		actorSM.ReceiveAxisRaw(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	// JUMP //

	void UpdateJump ()
	{
		actorSM.ReceiveJump(Input.GetButton("Jump"), Input.GetButtonDown("Jump"));
	}
}
