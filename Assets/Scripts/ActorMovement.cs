using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : MonoBehaviour {

	// SYSTEM //

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// MOVEMENT //

	public float speed;

	public void ReceiveAxis (float horizontal, float vertical)
	{
		Vector2 movement = GetMovement(horizontal, vertical);
		Move(movement);
	}

	Vector2 GetMovement (float horizontal, float vertical)
	{
		return new Vector2(horizontal, 0);
	}

	void Move (Vector2 movement)
	{
		rb.AddForce(movement * speed, ForceMode2D.Impulse);
	}

	// JUMP //

	public float jumpForce;

	public void ReceiveJump ()
	{
		Vector2 jump = GetJump();
		Jump(jump);
	}

	Vector2 GetJump ()
	{
		return new Vector3(0, jumpForce);
	}

	public void Jump (Vector2 jump)
	{
		rb.AddForce(jump, ForceMode2D.Impulse);
	}
}
