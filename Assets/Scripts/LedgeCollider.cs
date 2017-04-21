using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCollider : MonoBehaviour {

	// SYSTEM //

	public bool onLedge;

	// LEDGE CONTROL //

	

	// TRIGGER //

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Ledge" && !onLedge)
		{
			onLedge = true;
		}
	}
}
