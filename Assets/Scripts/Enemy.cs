using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CameraShake cameraShake;
    State state;
    PrefabManager prefabManager;

    void Start() {
        cameraShake = FindObjectOfType<CameraShake>();
        state = FindObjectOfType<State>();
        prefabManager = FindObjectOfType<PrefabManager>();
    }
    public void TriggerDeath() {
        cameraShake.SmallShake();
        state.UpGameScore();
        Vector2 pos = gameObject.transform.position;
        Instantiate(prefabManager.GetPrefab("explosion"), new Vector2(pos.x, pos.y - 0.2f), Quaternion.identity);
        Destroy(gameObject);
    }
}
