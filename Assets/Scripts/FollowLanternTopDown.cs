using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;
using Unity.VisualScripting;

public class FollowLanternTopDown : MonoBehaviour
{
    GameObject lantern;
    [SerializeField] float speed = .5f;
    Rigidbody2D rb2D;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        if (lantern!=null) MoveCharacter();
    }

    void MoveCharacter() {
        Vector3 currentLanternPos = lantern.transform.position;
        Vector3 direction = (currentLanternPos - transform.position).normalized;
        Vector3 step = direction * speed * Time.deltaTime;

        if (direction.x > 0) spriteRenderer.flipX = true;
        if (direction.x < 0) spriteRenderer.flipX = false;

        if (Vector3.Distance(transform.position, currentLanternPos) > 0.5f) rb2D.AddForce(F.vec2(step.x,step.y));

        //if (ray2D.collider != null && Vector3.Distance(transform.position, currentLanternPos) > 0.5f) transform.position = Vector3.MoveTowards(transform.position, currentLanternPos, step);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) Debug.Log("Collided with an obstacle");
    }
}
