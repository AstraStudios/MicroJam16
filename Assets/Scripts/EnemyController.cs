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
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector3 direction = (playerPos - transform.position).normalized;
        Vector3 step = direction * speed * Time.deltaTime;

        rb2D.AddForce(F.vec2(step.x,step.y));
    }
}
