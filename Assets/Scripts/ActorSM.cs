using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSM : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<ActorMovement>();
		anim = GetComponent<ActorAnimator>();
	}

	void Update ()
	{
		UpdateMovement();
		UpdateAnimator();
	}

	// INPUT //

	public float horizontal;
	public float vertical;

	public void ReceiveAxisRaw (float _horizontal, float _vertical)
	{
		horizontal = _horizontal;
		vertical = _vertical;
	}

	// MOVEMENT //

	ActorMovement movement;

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			movement.ReceiveInput(horizontal, vertical);
		}
	}

	// ANIMATOR //

	ActorAnimator anim;

	void UpdateAnimator ()
	{
		anim.ReceiveInput(horizontal, vertical);
	}
}
