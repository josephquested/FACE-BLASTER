using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States { Break, Idle };

public class ActorController : MonoBehaviour {

	public States state = States.Idle;

	// SYSTEM //

	void Start ()
	{
		actorMovement = GetComponent<ActorMovement>();
		actorJump = GetComponent<ActorJump>();
		actorAnim = GetComponent<ActorAnimator>();
		grounded = GetComponentInChildren<Grounded>();
		ledgeTrigger = GetComponentInChildren<LedgeTrigger>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
	}

	void Update ()
	{
		UpdateGrounded();
		UpdateJump();
		UpdateLedgeController();
		UpdateAnimator();
	}

	// INPUT //

	public void ReceiveAxis (float _horizontal, float _vertical)
	{
		horizontal = _horizontal;
		vertical = _vertical;
	}

	public void ReceiveJump (bool _jump, bool _jumpDown)
	{
		jump = _jump;
		jumpDown = _jumpDown;
	}

	// STATE //

	void Transition (States _state)
	{
		state = _state;
	}

	public bool CanTransition (States newState)
	{
		switch (state)
		{
			case States.Break:
				return new int[] { 1 }.Contains((int)newState);

			case States.Idle:
				return new int[] { 0 }.Contains((int)newState);

			default:
				return false;
		}
	}

	// MOVEMENT //

	ActorMovement actorMovement;

	float horizontal;
	float vertical;

	bool moving;

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			if (CanMove())
			{
				moving = true;
				actorMovement.ReceiveAxis(horizontal, vertical);
			}
		}
		else
		{
			moving = false;
		}
	}

	public bool CanMove ()
	{
		int[] moveableStates = new int[] { 1 };
		return moveableStates.Contains((int)state);
	}

	// JUMP //

	ActorJump actorJump;

	bool jump;
	bool jumpDown;
	bool jumping;

	void UpdateJump ()
	{
		if (isGrounded && jumpDown)
		{
			jumping = true;
		}
		if (jumping)
		{
			if (jump)
			{
				actorJump.ReceiveJump();
			}
			else
			{
				actorJump.StopJump();
				jumping = false;
			}
		}
	}

	// GROUNDED //

	Grounded grounded;
	bool isGrounded;

	void UpdateGrounded ()
	{
		isGrounded = grounded.isGrounded;
	}

	// LEDGE //

	LedgeTrigger ledgeTrigger;

	public GameObject hand;

	bool atLedge;

	void UpdateLedgeController ()
	{
		atLedge = ledgeTrigger.atLedge;
		hand.SetActive(atLedge);
		if (vertical < 0)
		{
			ledgeTrigger.Drop();
		}
	}

	// ANIMATOR //

	ActorAnimator actorAnim;

	void UpdateAnimator ()
	{
		actorAnim.ReceiveAxis(horizontal, vertical);
		actorAnim.ReceiveGrounded(isGrounded);
		actorAnim.ReceiveAtLedge(atLedge);
	}
}
