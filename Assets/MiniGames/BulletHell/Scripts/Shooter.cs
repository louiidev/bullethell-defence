using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shooter : MonoBehaviour {
    public GameObject Bullet;

    BoxCollider boxCollider2D;


    // Use this for initialization
    void Start () {
        StartCoroutine(FireBullet());
        boxCollider2D = transform.Find("Cube").GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
    Vector3 GetFirePosition() {
        return new Vector3(boxCollider2D.bounds.size.x,0,0);
    }

    IEnumerator FireBullet() {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Bullet, GetFirePosition(), Quaternion.identity);
        StartCoroutine(FireBullet());
    }
}
