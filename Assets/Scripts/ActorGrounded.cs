using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorGrounded : MonoBehaviour {

	// SYSTEM //

	public Transform topLeft;
	public Transform bottomRight;
	public LayerMask groundLayers;

	public bool grounded;

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);
	}
}
