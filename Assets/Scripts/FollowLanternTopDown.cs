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

    [SerializeField] float wobbleMaxAngle = 10;
    [SerializeField] float wobbleSpeed = 2;


    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        if (lantern!=null) MoveCharacter();
    }

    void MoveCharacter() {
        bool canSeeBug = false;
        foreach (GameObject bug in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance       = Vector2.Distance(bug.transform.position, transform.position);
            Vector2 bugDirection = (bug.transform.position - transform.position).normalized;

            // look for objects with ground tag in the way
            bool canSeeThisBug = true;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, bugDirection, distance);
            Debug.DrawLine(transform.position, transform.position + F.vec3(bugDirection,0)*distance);

            foreach (RaycastHit2D hit in hits)
                if (hit.transform.tag == "Ground") canSeeThisBug = false;

            if (canSeeThisBug) canSeeBug = true;
            
        }

        Vector3 currentLanternPos = lantern.transform.position;
        Vector3 direction = (currentLanternPos - transform.position).normalized;
        Vector3 step = direction * speed * Time.deltaTime;

        if (direction.x > 0) spriteRenderer.flipX = true;
        if (direction.x < 0) spriteRenderer.flipX = false;

        transform.eulerAngles = Vector3.zero;

        // move if safe from bug
        if (!canSeeBug)
        {
            if (Vector3.Distance(transform.position, currentLanternPos) > 0.5f) rb2D.AddForce(step.xy());
        }

        // wobble in fear otherwise
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time * wobbleSpeed) * wobbleMaxAngle);
        }
    }
}
