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
		UpdateRenderer();
	}

	// RENDERER //

	SpriteRenderer spriteRenderer;

	void UpdateRenderer ()
	{
		Vector2 mousePos = GetMousePosition();
		spriteRenderer.flipX = mousePos.x < transform.position.x;
	}

	// CURSOR //

	Vector2 GetMousePosition ()
	{
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    return Camera.main.ScreenToWorldPoint(mousePos);
	}
}
