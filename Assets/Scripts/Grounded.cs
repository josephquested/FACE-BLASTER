using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

	// SYSTEM //

	public bool isGrounded;

	// TRIGGERS //

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 8 && !isGrounded)
		{
			isGrounded = true;
		}
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 8 && !isGrounded)
		{
			isGrounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 8 && isGrounded)
		{
			print("left trigger!");
			isGrounded = false;
		}
	}
}
