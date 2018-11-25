using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 6f;
    public LayerMask enemyLayer;
    State state;
    InteractionManager interactionManager;
    // Start is called before the first frame update
    void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>();
        state = FindObjectOfType<State>();
        StartCoroutine(DestoryItself());
    }

    IEnumerator DestoryItself() {
        float randomRange = Random.Range(0.35f, 0.50f);
        yield return new WaitForSeconds(randomRange);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= transform.up * speed * state.gameTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.2f);
        if (hit) {
            interactionManager.OnBulletHit(hit.transform.gameObject);
            Destroy(this.gameObject);
        }
    }
}
