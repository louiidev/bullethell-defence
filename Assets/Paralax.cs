using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	GameObject background;
	GameObject bg1;
	GameObject bg2;
	float scrollSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		background = this.transform.Find("Background").gameObject;
		bg1 = background.transform.GetChild(0).gameObject;
		bg2 = background.transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		bg1.transform.position+=Vector3.down * Time.deltaTime * scrollSpeed;
		bg2.transform.position+=Vector3.down * Time.deltaTime * scrollSpeed;
	}
}
