using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_MP : MonoBehaviour {
	// Movement Speed
	public float speed = 120;
	public char team;

	// Initialize the balls for each side
	void Start () {
		if (team == 'g') {
			GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed;
			GetComponent<SpriteRenderer> ().color = Color.green;
		}
		else if (team == 'r') {
			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
			GetComponent<SpriteRenderer>().color = Color.red;
		}
	}
		
	/* Function for representation below
	 	ascii art:
		1  -0.5  0  0.5   1  <- x value
		===================  <- racket */
	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	// This function is called whenever the ball collides with another object
	void OnCollisionEnter2D(Collision2D col) {
		//if (col.gameObject.tag == "Player") 

		// Hit the rackets? (instead of walls)
		if (col.gameObject.tag == "Player") {
			// Calculate hit Factor
			float x=hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

			// Which racket did it hit?
			if (col.gameObject.name == "Racket1") {
				// Calculate direction, set length to 1
				Vector2 dir = new Vector2 (x, 1).normalized;
				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dir * speed;
				// Change Color when it toches the racket
				GetComponent<SpriteRenderer>().color = Color.red;
			} 

			else if (col.gameObject.name == "Racket2") {
				// Calculate direction, set length to 1
				Vector2 dir = new Vector2(x, -1).normalized;
				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dir * speed;
				// Change Color when it toches the racket
				GetComponent<SpriteRenderer>().color = Color.green;
			}
		}
	}
}
