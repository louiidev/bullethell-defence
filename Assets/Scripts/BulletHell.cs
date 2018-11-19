using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    State state;
    CameraShake cameraShake;
    PrefabManager prefabManager;
    InteractionManager interactionManager;
    
    bool canMove = false;
    bool canBeHit = true;

    float[] linesPosX = new float[] { -1f, 0, 1f };
    float moveLength = 1f;
    float coolDownTime = 0.7f;
    float movementSpeed = 10f;

    Vector3 startPosition = new Vector3(0, -1.35f);

    Animator playerAnim;    

    GameObject player;

    bool shouldFire = false;

    private void Start()
    {
        GetRequiredClasses();
        InitPlayer();
        StartCoroutine(InitObject());
    }

    void GetRequiredClasses() {
        state = FindObjectOfType<State>();
        cameraShake = FindObjectOfType<CameraShake>();
        prefabManager = FindObjectOfType<PrefabManager>();
        interactionManager = FindObjectOfType<InteractionManager>();
    }

    void InitPlayer() {
        player = Instantiate(prefabManager.GetPrefab("ship"), startPosition, Quaternion.identity);
        playerAnim = player.GetComponent<Animator>();
    }

    float GetRandomLane() {
        int random = Random.Range(0, 3);
        return linesPosX[random];
    }

    IEnumerator InitObject() {
        float random = Random.Range(0.8f, 1.6f);
        yield return new WaitForSeconds(random);
        int randomKey = Random.Range(7, 10);
        GameObject spawnGO = prefabManager.GetPrefab("asteroid");
        if (randomKey == 8) {
            spawnGO = prefabManager.GetPrefab("bulletPickup");
        } else if (randomKey == 9) {
            spawnGO = prefabManager.GetPrefab("healthPickup");
        }
        Instantiate(spawnGO, new Vector3(GetRandomLane(), 4), Quaternion.identity, this.transform);
        StartCoroutine(InitObject());
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
        CheckFire();
        Move();
    }

    void CheckFire() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            shouldFire = true;
            TriggerBullets();
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            shouldFire = false;
        }
    }

    void CheckHit() {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector3.up, 0.05f);
        Debug.DrawRay(player.transform.position, Vector2.up, Color.blue, 1);
        if (hit) {
            interactionManager.OnInteract(hit.transform.gameObject);
        }
    }

    public void TriggerBullets() {
        StartCoroutine(FireBullets());
    }

    IEnumerator FireBullets() {
        if (state.bulletAmount > 0) {
            float randomRot = Random.Range(-4, 4);
            Vector3 firePosition = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f);
            playerAnim.Play("Shooting", 0, 0);
            Instantiate(prefabManager.GetPrefab("Bullet"), firePosition, Quaternion.Euler(0, 0, randomRot));
            cameraShake.ExtraSmallShake();
            state.bulletAmount--;
            float randomSecs = Random.Range(0.1f, 0.14f);
            yield return new WaitForSeconds(randomSecs);
            if (shouldFire) {
                StartCoroutine(FireBullets());
            }
        }
    }

    IEnumerator PlayerHit() {
        state.playerData.ApplyDamage(1);
        playerAnim.Play("Attacked");
        canBeHit = false;
        yield return new WaitForSeconds(coolDownTime);
        canBeHit = true;
        playerAnim.Play("Idle");
    }

    bool CanMove(float newX) {
        foreach (float linePosX in linesPosX)
        {
            if (linePosX == newX) {
                return true;
            }
        }
        return false;
    }

    void Move()
    {
       if (Input.GetKeyDown(KeyCode.A) && CanMove(player.transform.position.x - moveLength)) {
           float positionToMoveX = player.transform.position.x - moveLength;
           Debug.Log(positionToMoveX);
           player.transform.position = new Vector3(positionToMoveX, player.transform.position.y);
       } else if (Input.GetKeyDown(KeyCode.D) && CanMove(player.transform.position.x + moveLength)) {
           float positionToMoveX = player.transform.position.x + moveLength;
           Debug.Log(positionToMoveX);
           player.transform.position = new Vector3(positionToMoveX, player.transform.position.y);
       }
    }
}
