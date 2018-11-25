using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

	public LayerMask enemyLayer;
	State state;
	CameraShake cameraShake;

	void Start() {
		cameraShake = FindObjectOfType<CameraShake>();
		state = FindObjectOfType<State>();
	}

	void Update() {
		CheckForAsteroids();
	}

	void CheckForAsteroids() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 100, enemyLayer);
		if (hit) {
			cameraShake.BigShake();
			Destroy(hit.transform.gameObject);
			state.amounts["worldHealth"]--;
		}
	}
}
