﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorFacing : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		UpdateFacing();
		UpdateRenderer();
		UpdateLedgeController();
	}

	// FACING //

	bool facingLeft;

	void UpdateFacing ()
	{
		Vector2 mousePos = GetMousePosition();
		facingLeft = mousePos.x < transform.position.x;
	}

	// RENDERER //

	SpriteRenderer spriteRenderer;

	void UpdateRenderer ()
	{
		spriteRenderer.flipX = facingLeft;
	}

	// LEDGE COLLIDER //

	public Transform ledgeControllerTrans;

	void UpdateLedgeController ()
	{
		if (facingLeft)
		{
			ledgeControllerTrans.eulerAngles = new Vector3(0, 180, 0);
		}
		else
		{
			ledgeControllerTrans.eulerAngles = new Vector3(0, 0, 0);
		}
	}

	// CURSOR //

	Vector2 GetMousePosition ()
	{
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    return Camera.main.ScreenToWorldPoint(mousePos);
	}
}
