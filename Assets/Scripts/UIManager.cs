using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    State state;
    GameObject canvas;
    BattleManager battleManager;

    Text healthText;
    Text scoreText;

    int health = 0;
    int score = 0;

    public Button AttackBtn;

	// Use this for initialization
	void Start () {
        state = FindObjectOfType<State>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    void Init () {
        canvas = GameObject.Find("Canvas");
        healthText = canvas.transform.Find("Health").transform.Find("Amount").GetComponent<Text>();
        scoreText = canvas.transform.Find("Score").transform.Find("Amount").GetComponent<Text>();
        AttackBtn = canvas.transform.Find("AttackBtn").GetComponent<Button>();
        AttackBtn.onClick.AddListener(state.battleManager.Attack);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    void AttackOnClick() {
    }


    void UpdateUI() {
        if (state.health != health) {
            health = state.health;
            healthText.text = health.ToString();
        }
        if (state.score != score) {
            score = state.score;
            scoreText.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateUI();
    }
}
