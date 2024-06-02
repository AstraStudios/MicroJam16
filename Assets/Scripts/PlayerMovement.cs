// origional script from castle clones by sustachio and astra studios

using GLSLVectors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 7f;

    [SerializeField] SpriteRenderer spriteRenderer;

        // Whether or not the player is grounded.
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        float verticalMove   = Input.GetAxis("Vertical")   * runSpeed * Time.deltaTime;
        rb2D.AddForce(F.vec2(horizontalMove, verticalMove));

        if (horizontalMove > 0)
            spriteRenderer.flipX = true;
        if (horizontalMove < 0)
            spriteRenderer.flipX = false;
    }
}