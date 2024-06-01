using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using GLSLVectors;

public class FollowLantern : MonoBehaviour
{
    GameObject lantern;
    GameObject closetGround;
    [SerializeField] LayerMask rampLayer;
    [SerializeField] LayerMask obstacleLayer;
    GameObject[] ramps; 
    GameObject[] obstacles; 
    GameObject[] ground;
    float speed = 20f;
    float groundDistance;
    Rigidbody2D rb2D;

    [SerializeField] float wobbleWalkMaxAngle = 10;
    [SerializeField] float wobbleSpeed = 6;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        ramps = GameObject.FindGameObjectsWithTag("Ramp");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        ground = GameObject.FindGameObjectsWithTag("Ground");
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 20f; //slam him into the ground because he wants to fly
    }

    // Update is called once per frame
    void Update()
    {
        // recompile por favor
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        if (lantern != null) MoveCharacter();
    }

    void MoveCharacter() {
        Vector3 targetPosition = F.vec3(lantern.transform.position.xy(), 0);
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 step = direction * speed * Time.deltaTime;

        // flip
        if (direction.x > 0)
            spriteRenderer.flipX = true;
        if (direction.y < 0)
            spriteRenderer.flipX = false;

        // check grounded (can't walk in air)
        bool grounded = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.transform.position.xy() + groundCheck.offset, groundCheck.size, LayerMask.GetMask("Ground"));
        for (int i = 0; i < colliders.Length; i++)
            if (colliders[i].tag == "Ground")
                grounded = true;

        // Raycast to detect obstacles
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, direction, step.magnitude, obstacleLayer);
        Debug.DrawRay(transform.position, direction * step.magnitude, Color.red);

        // Raycast to detect ramps
        RaycastHit2D hitRamp = Physics2D.Raycast(transform.position, direction, step.magnitude, rampLayer);
        Debug.DrawRay(transform.position, direction * step.magnitude, Color.blue);

        transform.eulerAngles = F.vec3(0, 0, 0);


        if (((hitObstacle.collider == null || hitRamp.collider != null) && grounded))
        {
            rb2D.MovePosition(transform.position + step);

            // wobble
            spriteRenderer.transform.eulerAngles = F.vec3(0, 0, Mathf.Sin(Time.time * wobbleSpeed) * wobbleWalkMaxAngle);
        } else Debug.Log("Hit an obstacle, cannot move further");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            // Handle logic when colliding with a ramp, if needed
            Debug.Log("Collided with a ramp");
            rb2D.gravityScale = 3f;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle logic when colliding with an obstacle
            Debug.Log("Collided with an obstacle");
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ramp")) rb2D.gravityScale = 20f;
    }
}
