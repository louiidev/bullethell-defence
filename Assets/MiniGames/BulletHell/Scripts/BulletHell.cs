using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    State state;
    
    bool canMove = false;
    bool canBeHit = true;

    float[] linesPosX = new float[] { -1f, 0, 1f };
    float moveLength = 1f;
    float coolDownTime = 0.7f;
    float movementSpeed = 10f;

    public GameObject line;
    public GameObject triangle;
    public GameObject bullet;
    public GameObject explosion;
    // private GameObject triangle;
    Animator animator;
    
    BoxCollider2D boxCollider2D;

    Animator playerAnim;

    private void Start()
    {
        animator = GetComponent<Animator>();
        state = GameObject.FindGameObjectWithTag("Manager").GetComponent<State>();
        InitPlayer();
        StartCoroutine(InitBullet());
    }

    void InitPlayer() {
        //triangle = Instantiate(trianglePrefab, new Vector2(linesPosX[1], 2), Quaternion.identity, this.transform);
        playerAnim = triangle.GetComponent<Animator>();
    }

    float GetRandomLane() {
        int random = Random.Range(0, 3);
        return linesPosX[random];
    }

    IEnumerator InitBullet() {
        float random = Random.Range(0.8f, 1.6f);
        yield return new WaitForSeconds(random);
        Instantiate(bullet, new Vector3(GetRandomLane(), 4), Quaternion.identity, this.transform);
        StartCoroutine(InitBullet());
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
        Move();
    }

    void CheckHit() {
        RaycastHit2D hit = Physics2D.Raycast(triangle.transform.position, Vector3.up, 0.15f);
        if (canBeHit && hit) {
            if (hit.transform.gameObject.tag == "Asteriod") {
                Vector2 pos = hit.transform.position;
                Destroy(hit.transform.gameObject);
                Instantiate(explosion, pos, Quaternion.identity);
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
       if (Input.GetKeyDown(KeyCode.A) && CanMove(triangle.transform.position.x - moveLength)) {
           float positionToMoveX = transform.position.x - moveLength;
           triangle.transform.position+= new Vector3(positionToMoveX, 0);
       } else if (Input.GetKeyDown(KeyCode.D) && CanMove(triangle.transform.position.x + moveLength)) {
           float positionToMoveX = transform.position.x + moveLength;
           triangle.transform.position+= new Vector3(positionToMoveX, 0);
       }
    }
}
