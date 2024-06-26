// origional script from castle clones by sustachio and astra studios

using GLSLVectors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewPlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 7f;
    [SerializeField] private float jumpForce = 1200f;      // Amount of force added when the player jumps.
    [SerializeField] private float jumpSlowMovement = 5f;

    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] SpriteRenderer spriteRenderer;

    public bool grounded;            // Whether or not the player is grounded.
    private Rigidbody2D rb2D;

    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * (grounded ? runSpeed : runSpeed/jumpSlowMovement) * Time.deltaTime;
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;

        transform.Translate(horizontalMove, 0, 0);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        FlipCharacter();
    }

    private void FixedUpdate()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.transform.position.xy() + groundCheck.offset, groundCheck.size, LayerMask.GetMask("Ground"));
        for (int i = 0; i < colliders.Length; i++)
            if (colliders[i].tag == "Ground")
                grounded = true;

        // Move our character
        Move(jump);
        jump = false;
    }

    void Move(bool jump)
    {
        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void FlipCharacter()
    {
        if (horizontalMove < 0)
            spriteRenderer.flipX = false;
        if (horizontalMove > 0)
            spriteRenderer.flipX = true;
    } 
}
