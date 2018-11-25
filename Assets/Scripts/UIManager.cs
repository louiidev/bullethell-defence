using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    State state;
    GameObject canvas;
    BattleManager battleManager;

    Text healthText;
    Text worldHealthText;
    Text scoreText;


	// Use this for initialization
	void Start () {
        state = FindObjectOfType<State>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    void Init () {
        canvas = GameObject.Find("Canvas");
        healthText = GetUiTextElement("Health");
        scoreText = GetUiTextElement("Score");
        worldHealthText = GetUiTextElement("WorldHealth");
    }

    Text GetUiTextElement(string elementName) {
        return canvas.transform.Find(elementName).transform.Find("Amount").GetComponent<Text>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    void TouchControls() {
        Touch[] touches = Input.touches;
        for(int i = 0; i < touches.Length; i++)
        {
            int id = touches[i].fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                GameObject go = EventSystem.current.currentSelectedGameObject;
                Debug.Log(go.name);
            }
        }
    }

    void UpdateUI() {
        healthText.text = state.amounts["health"].ToString();
        scoreText.text = state.amounts["score"].ToString();
        worldHealthText.text = state.amounts["worldHealth"].ToString();
    }

    void Update() {
        TouchControls();
    }

    // Update is called once per frame
    void LateUpdate () {
        UpdateUI();
    }
}
