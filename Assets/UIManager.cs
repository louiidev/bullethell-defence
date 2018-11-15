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

    public Button AttackBtn;

	// Use this for initialization
	void Start () {
        state = GameObject.FindGameObjectWithTag("Manager").GetComponent<State>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    void Init () {
        canvas = GameObject.Find("Canvas");
        playerHealthText = canvas.transform.Find("PlayerHealth").transform.Find("Amount").GetComponent<Text>();
        AttackBtn = canvas.transform.Find("AttackBtn").GetComponent<Button>();
        AttackBtn.onClick.AddListener(state.battleManager.Attack);
    
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
    }

    // Update is called once per frame
    void Update () {
        UpdateHealth();
    }
}
