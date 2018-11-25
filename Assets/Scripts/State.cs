using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State : MonoBehaviour {
    public Dictionary<string, int> amounts = new Dictionary<string, int>();

    public float gameSpeed = 0;

    public float gameTime;
    bool gamePaused = false;
    bool canBeDamaged = true;

    public WeaponManager weaponManager;
    public UIManager uIManager;
    public BulletHell bulletHell;

    void SetupAmounts() {
        amounts.Add("health", 4);
        amounts.Add("worldHealth", 6);
        amounts.Add("score", 0);
    }

    void Awake()
    {
        InitManagers();
    }

    void InitManagers() {
        uIManager = FindObjectOfType<UIManager>();
        bulletHell = GetComponent<BulletHell>();
        weaponManager = new WeaponManager();
    }

    void Start() {
        SetupAmounts();
    }

    public void UpGameSpeed() {
        gameSpeed+= 0.1f;
    }

    void Update() {
        if (!gamePaused) {
            gameTime = Time.deltaTime;
        } else {
            gameTime = 0;
        }
    }

    public void TogglePause(bool pause) {
        gamePaused = pause;
    }

    public void UpGameScore() {
        amounts["score"]++;
        if (amounts["score"] % 10 == 0) {
            UpGameSpeed();
        }
    }

    IEnumerator DamageSetTimeOut() {
        canBeDamaged = false;
        amounts["health"]--;
        if (amounts["health"] > 0) {
            bulletHell.playerAnim.Play("Hit");
            yield return new WaitForSeconds(2f);
            bulletHell.playerAnim.Play("Idle");
            canBeDamaged = true;
        } else {
            // trigger death
        }
    }

    public void DamagePlayer() {
        if (canBeDamaged) {
            StartCoroutine(DamageSetTimeOut());
        }
    }
}
