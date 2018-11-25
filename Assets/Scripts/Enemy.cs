using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CameraShake cameraShake;
    State state;
    PrefabManager prefabManager;
    int health = 2;
    MoveObejectDown moveObeject;
    Animator animator;

    void Start() {
        cameraShake = FindObjectOfType<CameraShake>();
        state = FindObjectOfType<State>();
        prefabManager = FindObjectOfType<PrefabManager>();
        moveObeject = GetComponent<MoveObejectDown>();
        animator = GetComponent<Animator>();
    }


    public void Damage() {
        Debug.Log("fires");
        health--;
        StartCoroutine(QuickPause());
    }

    void Destroy() {
        Vector2 pos = gameObject.transform.position;
        Instantiate(prefabManager.GetPrefab("explosion"), new Vector2(pos.x, pos.y - 0.2f), Quaternion.identity);
        Destroy(gameObject);
    }

    void PushBack() {
        this.transform.position+= new Vector3(0, this.transform.position.y - 1);
    }

    IEnumerator QuickPause() {
        state.TogglePause(true);
        yield return new WaitForSeconds(0.035f);
        state.TogglePause(false);
        moveObeject.PushBack();
        if (health <= 0) {
            Destroy();
             cameraShake.BigShake();
        } else {
            cameraShake.SmallShake();
            animator.Play("hit");
        }
    }

}
