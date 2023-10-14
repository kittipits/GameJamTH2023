using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    //private Animator anim;

    [SerializeField] private LayerMask groundLayer;

    private float moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;


    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (moveInput > 0f)
        {
            sprite.flipX = false;
        }
        else if (moveInput < 0f)
        {
            sprite.flipX = true;
        }

        //UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    //private void UpdateAnimationState()
    //{
    //    MovementState state;

    //    if (moveInput > 0f)
    //    {
    //        state = MovementState.running;
    //        sprite.flipX = false;
    //    }
    //    else if (moveInput < 0f)
    //    {
    //        state = MovementState.running;
    //        sprite.flipX = true;
    //    }
    //    else
    //    {
    //        state = MovementState.idle;
    //    }

    //    if (rb.velocity.y > .1f)
    //    {
    //        state = MovementState.jumping;
    //    }
    //    else if (rb.velocity.y < -.1f)
    //    {
    //        state = MovementState.falling;
    //    }

    //    anim.SetInteger("state", (int)state);
    //}
}
