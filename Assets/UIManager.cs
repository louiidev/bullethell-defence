using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    State state;
    GameObject canvas;
    BattleManager battleManager;

    Text playerHealthText;
    int playerHealth;

    Text enemyHealthText;
    int enemyHealth;

    public Button AttackBtn;

	// Use this for initialization
	void Start () {
        state = GameObject.FindGameObjectWithTag("Manager").GetComponent<State>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    void Init () {
        canvas = GameObject.Find("Canvas");
        if (state.inBattle)
        {
            playerHealthText = canvas.transform.Find("PlayerHealth").transform.Find("Amount").GetComponent<Text>();
            enemyHealthText = canvas.transform.Find("EnemyHealth").transform.Find("Amount").GetComponent<Text>();
            AttackBtn = canvas.transform.Find("AttackBtn").GetComponent<Button>();
            AttackBtn.onClick.AddListener(state.battleManager.Attack);
        }
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    void AttackOnClick() {
    }


    void UpdateHealth() {
        if (playerHealthText && state.playerData.health != playerHealth) {
            playerHealth = state.playerData.health;
            playerHealthText.text = playerHealth.ToString();
        }

        if (enemyHealthText && state.currentEnemy.health != enemyHealth)
        {
            enemyHealth = state.currentEnemy.health;
            enemyHealthText.text = enemyHealth.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateHealth();
    }
}
