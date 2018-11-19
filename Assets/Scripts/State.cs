using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State : MonoBehaviour {

    public int score = 0;
    public int health = 4;
    public int bulletAmount = 0;
    public float gameSpeed = 0;

    public GameObject player;
    public PlayerData playerData;
    public BattleManager battleManager;
    public UIManager uIManager;
    public BulletHell bulletHell;

    public bool inBattle = false;
    public bool inBulletHell = false;

    public void SetBulletAmount(int bulletAmount) {
        this.bulletAmount = bulletAmount;
    }

    void Awake()
    {
        playerData = new PlayerData();
        player = GameObject.FindWithTag("Player");
        InitManagers();
    }

    public void UpGameSpeed() {
        gameSpeed+= 0.1f;
    }

    public void UpGameScore() {
        score+= 1;
        if (score % 10 == 0) {
            UpGameSpeed();
        }
    }

    void InitManagers() {
        battleManager = FindObjectOfType<BattleManager>();
        uIManager = FindObjectOfType<UIManager>();
        bulletHell = GetComponent<BulletHell>();
    }
}
