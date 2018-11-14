using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	bool canMove = true;
	[SerializeField]
	float movementSpeed = 80f;
	Rigidbody2D rigidbody2D;
	Vector2[] directions = new Vector2[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move()
	{
			if (canMove) {
					rigidbody2D.velocity = Vector2.zero;
					Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
					if (movement != Vector3.zero) {
						
						rigidbody2D.AddForce(movement * movementSpeed * Time.deltaTime);
					}
					
					
					// Vector3 movement = Vector3.right;
					
			}
		
	}
}
