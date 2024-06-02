using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D rb2D;
    Vector3 playerPos;
    float speed = .05f;
    GameObject player;
    bool hasLineOfSight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 step;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (Vector3.Distance(playerPos, transform.position) < 5f) {
            Vector3 direction = (playerPos - transform.position).normalized;
            step = direction * speed * Time.deltaTime;
        } else {
            Vector3 direction = (new Vector3(Random.Range(-40f,40f), Random.Range(-40f, 40f), 0) - transform.position).normalized;
            step = direction * speed * Time.deltaTime;
        }

        rb2D.AddForce(F.vec2(step.x,step.y));
    }
}
