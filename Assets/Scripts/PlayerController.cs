using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    //private Animator anim;

    [SerializeField] private LayerMask groundLayer;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;
    Vector2 vecGravity; 

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //move
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //jump
        if (Input.GetKey("space") && IsGrounded())
        {
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //gravity
        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallForce * Time.deltaTime;
        }

        //flip
        if (dirX > 0f)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
        }

        //UpdateAnimationState();
    }

    //private void UpdateAnimationState()
    //{
    //    MovementState state;

    //    if (dirX > 0f)
    //    {
    //        state = MovementState.running;
    //        sprite.flipX = false;
    //    }
    //    else if (dirX < 0f)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
