using System;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 3f;

    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSoundEffect;
    private float dirX = 0f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log("Selected Character ID in Next Scene: " + GameManager.SelectedCharacterID);
        InitializeAnimations(GameManager.SelectedCharacterID);
    }
    void InitializeAnimations(int characterID)
    {
        Debug.Log(characterID);
        if (characterID == 1)
        {
            anim.SetTrigger("character1");
        }
        else 
        {
            anim.SetTrigger("character2");
        }
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
       
        UpdateAnimation(dirX);
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdateAnimation(float dirX)
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) // || rb.velocity.y < -.1f
        {            
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}