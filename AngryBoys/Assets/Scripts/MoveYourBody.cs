using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Move the player left and right
        float move = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        // Make the player jump if on the ground and the up arrow key is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump input received");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }        
        // Check for arrow key input

    }
}
