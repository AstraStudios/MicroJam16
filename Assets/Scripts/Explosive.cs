using System.Collections;
using System.Collections.Generic;
using GLSLVectors;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    Rigidbody2D enemyRB;
    [SerializeField] ParticleSystem explosionParticles;

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
        if (enemyRB != null)    enemyRB.AddForce(F.vec2(Random.Range(-transform.position.x, transform.position.x), Random.Range(-transform.position.y, transform.position.y))); ParticleSystem spawnedParticles = Instantiate(explosionParticles, transform.position, Quaternion.identity); spawnedParticles.Play(); Destroy(gameObject);
    }

    IEnumerator MakeBudNormal() {
        yield return new WaitForSeconds(1.5f);
        enemyRB.drag -= 50f;
    }
}
