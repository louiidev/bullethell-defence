using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    public GameObject bulletHell;

    State state;

    bool test = true;

    void Start()
    {
        state = FindObjectOfType<State>();
    }

    void EndBattle() {
        Debug.Log("battle over");
    }

    void EnemyAttack() {
        if (state.inBattle)
        {
            state.inBulletHell = true;
            TriggerBulletHell();
        }
    }

    void TriggerBulletHell() {
        Instantiate(bulletHell, Vector2.zero, Quaternion.identity);
    }

    public void Attack() {
        EnemyAttack();
        if (!state.inBattle) {
            EndBattle();
        }
    }
}
