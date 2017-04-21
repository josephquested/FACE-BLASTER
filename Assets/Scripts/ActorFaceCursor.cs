using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorFaceCursor : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		UpdateFacing();
		UpdateRenderer();
		UpdateLedgeCollider();
	}

	// FACING //

	public bool facingLeft;

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

	public Transform ledgeColliderTransform;

	void UpdateLedgeCollider ()
	{
		if (facingLeft)
		{
			ledgeColliderTransform.eulerAngles = new Vector3(0, 180, 0);
		}
		else
		{
			ledgeColliderTransform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

	// CURSOR //

	Vector2 GetMousePosition ()
	{
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    return Camera.main.ScreenToWorldPoint(mousePos);
	}
}
