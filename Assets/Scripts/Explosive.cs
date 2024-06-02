using System.Collections;
using System.Collections.Generic;
using GLSLVectors;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Enemy")) {
            enemyRB = collider.GetComponent<Rigidbody2D>();
            enemyRB.drag += 50f;
            StartCoroutine(MakeBudNormal());
        }
    }

    IEnumerator DestroyAfterSeconds() {
        yield return new WaitForSeconds(2);
        enemyRB.AddForce(F.vec2(10,10));
        Destroy(gameObject);
    }

    IEnumerator MakeBudNormal() {
        yield return new WaitForSeconds(4);
        enemyRB.drag -= 50f;
    }
}
