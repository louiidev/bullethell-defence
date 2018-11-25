using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button StartButton;

    void Start() {
        StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        StartButton.onClick.AddListener(ButtonClick);
    }

    void ButtonClick() {
        StartCoroutine(TriggerButton());

    }


    IEnumerator TriggerButton() {
        StartButton.GetComponent<Animator>().Play("Start");
        yield return new WaitForSeconds(0.20f);
        StartButton.GetComponent<Animator>().Play("Idle");
        yield return new WaitForSeconds(0.7f);
        // change scene
        SceneManager.LoadScene("Battle");
    }
}
