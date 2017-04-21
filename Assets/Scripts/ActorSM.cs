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
		ledgeTrigger = GetComponentInChildren<LedgeTrigger>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
		UpdateGrounded();
	}

	void Update ()
	{
		UpdateJump();
		UpdateAtLedge();
		UpdateLedgeDrop();
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

	public GameObject handCollider;
	LedgeTrigger ledgeTrigger;

	void UpdateAtLedge ()
	{
		handCollider.SetActive(ledgeTrigger.atLedge);
	}

	void UpdateLedgeDrop ()
	{
		if (vertical < 0)
		{
			ledgeTrigger.ForceDrop();
		}
	}

	// ANIMATOR //

	ActorAnimator anim;

	void UpdateAnimator ()
	{
		anim.ReceiveAxis(horizontal, vertical);
		anim.ReceiveGrounded(grounded);
		anim.ReceiveAtLedge(ledgeTrigger.atLedge);
	}
}
