using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeTrigger : MonoBehaviour {

	// SYSTEM //

	public bool atLedge;

	// LEDGE //

	public void Drop ()
	{
		atLedge = false;
	}

	// TRIGGER //

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Ledge" && !atLedge)
		{
			atLedge = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.tag == "Ledge" && atLedge)
		{
			atLedge = false;
		}
	}
}
