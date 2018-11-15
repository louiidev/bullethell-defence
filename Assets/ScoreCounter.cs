using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

	public LayerMask asteroidLayerMask;
	State state;

	void Start() {
		state = FindObjectOfType<State>();
	}

	void Update() {
		CheckForAsteroids();
	}

	void CheckForAsteroids() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 100, asteroidLayerMask);
		if (hit) {
			Destroy(hit.transform.gameObject);
			state.playerData.ApplyDamage(1);
		}
	}
}
