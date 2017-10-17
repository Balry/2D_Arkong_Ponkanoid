using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
	// Movement Speed
	public float speed = 120;
	public string axis;

	void FixedUpdate () {
		// Get Horizontal Input
		float h = Input.GetAxisRaw(axis);
		// Set Velocity (movement direction * speed)
		GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
	}
}
