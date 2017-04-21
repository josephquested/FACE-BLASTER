using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSM : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<ActorMovement>();
		anim = GetComponent<ActorAnimator>();
		rb = GetComponent<Rigidbody2D>();
		groundedCollider = GetComponentInChildren<GroundedCollider>();
		ledgeCollider = GetComponentInChildren<LedgeCollider>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
		UpdateGrounded();
	}

	void Update ()
	{
		UpdateJump();
		UpdateOnLedge();
		UpdateAnimator();
	}

	// MOVEMENT //

	Rigidbody2D rb;
	ActorMovement movement;

	float horizontal;
	float vertical;

	bool canMove = true;

	public void ReceiveAxisRaw (float _horizontal, float _vertical)
	{
		horizontal = _horizontal;
		vertical = _vertical;
	}

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			if (canMove)
			{
				movement.ReceiveAxis(horizontal, vertical);
			}
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
			jumping = true;
		}
		if (jumping)
		{
			if (jump)
			{
				movement.ReceiveJump();
			}
			else
			{
				movement.StopJump();
				jumping = false;
			}
		}
	}

	// GROUNDED //

	GroundedCollider groundedCollider;

	bool grounded;

	void UpdateGrounded ()
	{
		grounded = groundedCollider.grounded;
	}

	// LEDGE //

	LedgeCollider ledgeCollider;

	bool onLedge;

	void UpdateOnLedge ()
	{
		onLedge = ledgeCollider.onLedge;

		if (onLedge && rb.gravityScale == 1)
		{
			canMove = false;
			rb.velocity = Vector3.zero;
			rb.gravityScale = 0;
		}

		if (!onLedge && rb.gravityScale == 0)
		{
			canMove = true;
			rb.gravityScale = 1;
		}
	}

	// ANIMATOR //

	ActorAnimator anim;

	void UpdateAnimator ()
	{
		anim.ReceiveAxis(horizontal, vertical);
		anim.ReceiveGrounded(grounded);
		anim.ReceiveOnLedge(onLedge);
	}
}
