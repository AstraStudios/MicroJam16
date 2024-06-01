using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        ramps = GameObject.FindGameObjectsWithTag("Ramp");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        ground = GameObject.FindGameObjectsWithTag("Ground");
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(lantern.transform.position.x, lantern.transform.position.y, 0);
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 step = direction * speed * Time.deltaTime;

        for (int o = 0; o < ground.Length; o++) {
            Vector3 diff = ground[o].transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < Mathf.Infinity) {
                closetGround = ground[o];
            }
        }

        // Raycast to detect obstacles
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, direction, step.magnitude, obstacleLayer);
        Debug.DrawRay(transform.position, direction * step.magnitude, Color.red);

        // Raycast to detect ramps
        RaycastHit2D hitRamp = Physics2D.Raycast(transform.position, direction, step.magnitude, rampLayer);
        Debug.DrawRay(transform.position, direction * step.magnitude, Color.blue);

        groundDistance = transform.position.y - closetGround.transform.position.y;
        if (hitObstacle.collider == null || hitRamp.collider != null && groundDistance < 1f)
        {
            rb2D.MovePosition(transform.position + step);
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
        if (collision.gameObject.CompareTag("Ramp")) rb2D.gravityScale = 14f;
    }
}
