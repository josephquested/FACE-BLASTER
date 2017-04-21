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

	public void ReceiveAxis (float horizontal, float vertical)
	{
		anim.SetBool("Moving", horizontal != 0);
	}

	public void ReceiveGrounded (bool grounded)
	{
		anim.SetBool("Airborne", !grounded);
	}
}
