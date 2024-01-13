using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask jumpableGround;
    private float moveSpeed = 5f;
    private float jumpForce = 3f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal"); // Raw lets you get back to 0 immediately
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}