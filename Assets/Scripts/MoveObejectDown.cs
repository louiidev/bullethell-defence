using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObejectDown : MonoBehaviour {

	float speed = 1.8f;
	State state;

	Vector3 direction = Vector3.down;

	void Start() {
		state = FindObjectOfType<State>();
	}

	void Update() {
		transform.position+= direction * (speed + state.gameSpeed) * state.gameTime;
	}

	public void PushBack() {
		StartCoroutine(TriggerFlipDirection());
	}

	IEnumerator TriggerFlipDirection() {
		direction = Vector3.up * 1.4f;
		yield return new WaitForSeconds(0.02f);
		direction = Vector3.zero;
		yield return new WaitForSeconds(0.1f);
		direction = Vector3.down;
	}
	
}
