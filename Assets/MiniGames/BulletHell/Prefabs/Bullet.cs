using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float speed = 4f;

	void Update() {
		transform.position+= Vector3.down * speed * Time.deltaTime;
	}
	
}
