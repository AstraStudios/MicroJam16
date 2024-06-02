using System.Collections;
using System.Collections.Generic;
using GLSLVectors;
using UnityEngine;

public class Explosive : MonoBehaviour
{
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
            collider.GetComponent<Rigidbody2D>().drag += 50f;
            collider.GetComponent<Rigidbody2D>().AddForce(F.vec2(10,10));
        }
    }

    IEnumerator DestroyAfterSeconds() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
