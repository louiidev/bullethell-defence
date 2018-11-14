using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State : MonoBehaviour {

    public GameObject player;
    public PlayerData playerData;
    public Enemy currentEnemy;
    public BattleManager battleManager;
    public EnemyManager enemyManager;
    public UIManager uIManager;

    public bool inBattle = false;
    public bool inBulletHell = false;

    void Awake()
    {
        playerData = new PlayerData();
        player = GameObject.FindWithTag("Player");
        InitManagers();
    }

    void InitManagers() {
        battleManager = FindObjectOfType<BattleManager>();
        uIManager = FindObjectOfType<UIManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }
}
