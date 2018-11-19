using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float speed = 1f;
    void Start() {
        StartCoroutine(KillGO());
    }

    void Update() {
        transform.position+= Vector3.down * speed * Time.deltaTime;
    }

    IEnumerator KillGO() {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
    }
}
