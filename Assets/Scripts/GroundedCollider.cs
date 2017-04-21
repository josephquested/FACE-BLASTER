using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCollider : MonoBehaviour {

	// SYSTEM //

	public bool grounded;

	// TRIGGERS //

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 8 && !grounded)
		{
			grounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 8 && grounded)
		{
			grounded = false;
		}
	}
}
