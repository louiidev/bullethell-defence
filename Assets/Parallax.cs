using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	float scrollSpeed = 0.25f;
	Camera camera;
	Vector3 startPos;
	SpriteRenderer sprite;
	float height;
	float cameraHeight = 6.5f;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		Debug.Log(startPos.y);
		camera = FindObjectOfType<Camera>();
		sprite = GetComponent<SpriteRenderer>();
		height = sprite.bounds.size.y;
	}

	void ParalaxBg() {
		if (transform.position.y < -cameraHeight) {
			transform.position = new Vector3(0, cameraHeight);
		}
	}
	
	// Update is called once per frame
	void Update () {
		ParalaxBg();
		this.transform.position+=Vector3.down * Time.deltaTime * scrollSpeed;
	}
}
