using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;
using Unity.Mathematics;

public class CombatController : MonoBehaviour
{

    [SerializeField] float pushMaxDistance = 3;
    [SerializeField] float pushPower = .001f;

    void Update()
    {
        // sweep enemys away
        if (Input.GetMouseButtonDown(1)) {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) 
            {
                float distance    = Vector3.Distance(transform.position, enemy.transform.position);
                Vector2 direction = (enemy.transform.position - transform.position).normalized;

                if (distance > pushMaxDistance) continue;

                enemy.GetComponent<Rigidbody2D>().AddForce(direction * (pushMaxDistance - distance) * pushPower, ForceMode2D.Impulse);
            }
        }
    }
}
