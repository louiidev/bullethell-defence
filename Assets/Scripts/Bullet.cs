using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 6f;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoryItself());
    }

    IEnumerator DestoryItself() {
        float randomRange = Random.Range(0.25f, 0.40f);
        yield return new WaitForSeconds(randomRange);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= transform.up * speed * Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.2f, enemyLayer);
        if (hit) {
            hit.transform.GetComponent<Enemy>().TriggerDeath();
            Destroy(gameObject);
        }
    }
}
