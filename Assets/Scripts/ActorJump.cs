using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorJump : MonoBehaviour {

	// SYSTEM //

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// JUMP //

	public float jumpForce;
	public float jumpMax;

	float jumpCurrent = 0;

	public void ReceiveJump ()
	{
		Vector2 jump = GetJump();
		Jump(jump);
	}

	public void StopJump ()
	{
		jumpCurrent = 0;
	}

	Vector2 GetJump ()
	{
		return new Vector3(0, jumpForce);
	}

	void Jump (Vector2 jump)
	{
		jumpCurrent += 0.1f;
		if (jumpCurrent < jumpMax)
		{
			rb.AddForce(jump, ForceMode2D.Impulse);
		}
	}
}
