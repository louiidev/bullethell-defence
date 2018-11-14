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

    public void StartBattle(GameObject enemyGO) {
        SceneManager.LoadScene("Battle");
        state.inBattle = true;
        state.currentEnemy = state.enemyManager.GetEnemy(enemyGO.name.ToLower());
    }

    void EndBattle() {
        Debug.Log("battle over");
    }

    void PlayerAttack() {
        if (state.inBattle) {
            state.currentEnemy.ApplyDamage(state.playerData.attack);
            state.inBattle &= state.currentEnemy.alive;
        }
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
        PlayerAttack();
        EnemyAttack();
        if (!state.inBattle) {
            EndBattle();
        }
    }
}
