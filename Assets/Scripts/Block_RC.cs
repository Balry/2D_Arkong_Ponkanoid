using UnityEngine;
using System.Collections;

public class Block_RC : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		// Destroy the whole Block
		Destroy(gameObject);
	}
}