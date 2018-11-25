using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilMethods;

public class BulletHell : MonoBehaviour
{
    State state;
    CameraShake cameraShake;
    PrefabManager prefabManager;
    InteractionManager interactionManager;
    
    bool canMove = false;
    bool canBeHit = true;

    float[] linesPosX = new float[] { -1f, -0.5f, 0, 0.5f, 1f };
    float moveLength = 1f;
    float coolDownTime = 0.7f;
    float movementSpeed = 10f;
   
    public LayerMask wallLayer;

    Vector3 startPosition = new Vector3(0, -1.35f);

    public Animator playerAnim;    

    public GameObject player;

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
        return linesPosX.GetRandomValue();
    }

    IEnumerator InitObject() {
        float random = Random.Range(0.4f, 1.3f);
        yield return new WaitForSeconds(random);
        int randomKey = Random.Range(0, 50);
        GameObject spawnGO = prefabManager.GetPrefab("asteroid");
        Debug.Log(spawnGO);
        Debug.Log(Resources.Load("Prefabs/asteroid") as GameObject);
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
            if (!shouldFire) {
                shouldFire = true;
                playerAnim.Play("Fire");
                TriggerBullets();
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            playerAnim.Play("Idle");
            shouldFire = false;
        }
    }

    void CheckHit() {
        Vector3 startPos = new Vector3(player.transform.position.x, player.transform.position.y - 0.25f);
        RaycastHit2D[] hits = {
            Physics2D.Raycast(new Vector3(startPos.x - 0.23f, startPos.y), Vector3.up, 0.25f),
            Physics2D.Raycast(startPos, Vector3.up, 0.48f),
            Physics2D.Raycast(new Vector3(startPos.x + 0.23f, startPos.y), Vector3.up, 0.25f),
        };
        Debug.DrawRay(startPos, Vector2.up * 0.48f, Color.blue, 0.1f);
        Debug.DrawRay(new Vector3(startPos.x + 0.23f, startPos.y), Vector2.up * 0.25f, Color.red, 0.1f);
        Debug.DrawRay(new Vector3(startPos.x - 0.23f, startPos.y), Vector2.up * 0.25f, Color.green, 0.1f);
        foreach(RaycastHit2D hit in hits) {
            if (hit) {
                interactionManager.OnInteract(hit.transform.gameObject);
                break;
            }
        }
        
    }

    public void TriggerBullets() {
        StartCoroutine(FireBullets());
    }

    IEnumerator FireBullets() {
        if (state.weaponManager.bulletAmount > 0) {
            float randomRot = Random.Range(-8, 8);
            Vector3 firePosition = new Vector3(player.transform.position.x, player.transform.position.y + 0.25f);
            Instantiate(prefabManager.GetPrefab("Bullet"), firePosition, Quaternion.Euler(0, 0, randomRot));
            cameraShake.ExtraSmallShake();
            state.weaponManager.MinusBulletAmount();
            float randomSecs = Random.Range(0.1f, 0.14f);
            yield return new WaitForSeconds(randomSecs);
            if (shouldFire) {
                StartCoroutine(FireBullets());
            }
        }
    }

    IEnumerator PlayerHit() {
        playerAnim.Play("Attacked");
        canBeHit = false;
        yield return new WaitForSeconds(coolDownTime);
        canBeHit = true;
        playerAnim.Play("Idle");
    }

    bool CanMove(float x) {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, new Vector3(x, 0), 0.3f, wallLayer);
        Debug.DrawRay(player.transform.position, new Vector3(x, 0) * 0.3f, Color.red, 0.1f);
        return !hit;
    }

    void Move()
    {
        float speed = 4f;
        float x = Input.GetAxis("Horizontal");
        if ((x > 0 || x < 0) && CanMove(x)) {
             Vector3 pos = new Vector3(x, 0) * state.gameTime * speed;
             player.transform.position+= pos;
        }
    }
}
