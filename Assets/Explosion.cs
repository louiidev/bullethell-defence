using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start() {
        StartCoroutine(KillGO());
    }

    IEnumerator KillGO() {
        yield return new WaitForSeconds(0.24f);
        Destroy(gameObject);
    }
}
