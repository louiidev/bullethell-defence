using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float speed = 1f;
    State state;
    void Start() {
        state = FindObjectOfType<State>();
        StartCoroutine(KillGO());
    }

    void Update() {
        transform.position+= Vector3.down * speed * state.gameTime;
    }

    IEnumerator KillGO() {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
    }
}
