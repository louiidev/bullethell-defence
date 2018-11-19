using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObejectDown : MonoBehaviour {

	float speed = 1.8f;
	State state;

	void Start() {
		state = FindObjectOfType<State>();
	}

	void Update() {
		transform.position+= Vector3.down * (speed + state.gameSpeed) * Time.deltaTime;
	}
	
}
