using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSM : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<ActorMovement>();
		actorGrounded = GetComponent<ActorGrounded>();
		anim = GetComponent<ActorAnimator>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
		UpdateGrounded();
	}

	void Update ()
	{
		UpdateJump();
		UpdateAnimator();
	}

	// MOVEMENT //

	ActorMovement movement;

	public float horizontal;
	public float vertical;

	public void ReceiveAxisRaw (float _horizontal, float _vertical)
	{
		horizontal = _horizontal;
		vertical = _vertical;
	}

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			movement.ReceiveAxis(horizontal, vertical);
		}
	}

	// JUMP //

	bool jump;
	bool jumpDown;

	bool jumping;

	public void ReceiveJump (bool _jump, bool _jumpDown)
	{
		jump = _jump;
		jumpDown = _jumpDown;
	}

	void UpdateJump ()
	{
		if (grounded && jumpDown)
		{
			movement.ReceiveJump();
		}
	}

	// GROUNDED //

	ActorGrounded actorGrounded;

	bool grounded;

	void UpdateGrounded ()
	{
		grounded = actorGrounded.grounded;
	}

	// ANIMATOR //

	ActorAnimator anim;

	void UpdateAnimator ()
	{
		anim.ReceiveAxis(horizontal, vertical);
		anim.ReceiveGrounded(grounded);
	}
}
