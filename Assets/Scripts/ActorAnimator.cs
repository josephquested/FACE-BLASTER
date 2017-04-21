using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimator : MonoBehaviour {

	// SYSTEM //

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	// MOVEMENT //

	bool atLedge;

	public void ReceiveAxis (float horizontal, float vertical)
	{
		anim.SetBool("Moving", horizontal != 0 && !atLedge);
	}

	public void ReceiveGrounded (bool grounded)
	{
		anim.SetBool("Airborne", !grounded);
	}

	public void ReceiveAtLedge (bool _atLedge)
	{
		atLedge = _atLedge;
	}
}
