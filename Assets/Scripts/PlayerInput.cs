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

	void Update ()
	{
		UpdateAxisRaw();
	}

	// MOVEMENT //

	void UpdateAxisRaw ()
	{
		actorSM.ReceiveAxisRaw(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
