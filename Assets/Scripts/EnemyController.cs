using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float wanderForce = 1000;
    [SerializeField] float wanderMinTime = 1.5f;
    [SerializeField] float wanderMaxTime = 3;

    Vector3 wanderDirection;
    float wanderTimer = 0;

    void Update()
    {
        wanderTimer -= Time.deltaTime;

        // pick random direction and re randomize timer
        if (wanderTimer <= 0)
        {
            wanderTimer = Random.Range(wanderMinTime, wanderMaxTime);
            wanderDirection = new Vector3(Random.value - .5f, Random.value - .5f, Random.value - .5f).normalized;
        }

        GetComponent<Rigidbody2D>().AddForce(wanderDirection * wanderForce);
    }
}
