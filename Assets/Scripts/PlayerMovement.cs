using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask groundLayer;

    public float moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpMultiplier;
    Vector2 vecGravity;
    public Transform groundCheck;
    bool isJumping;
    float jumpCounter;

    [SerializeField] private AudioSource jumpSoundEffect;

    [Header("Knockback")]
    [SerializeField] private Transform center;
    [SerializeField] private float knockbackVel = 8f;
    [SerializeField] private float knockbackTime = 1f;
    [SerializeField] private bool knockbacked;
    public bool canMove;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canMove = true;

        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            MovementHandle();
        }
    }

    void MovementHandle()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() && rb.velocity.y == 0)
        {
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            anim.SetBool("jumping", true);
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump")) 
        {
            isJumping = false;
        }

        if (moveInput > 0f)
        {
            transform.localScale = Vector3.one;
            anim.SetBool("running", true);
        }
        else if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("jumping", false);
        }
        else
        {
            anim.SetBool("jumping", true);
        }
    }

    private void FixedUpdate()
    {       
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    public void Knockback(Transform t)
    {
        var dir = center.position - t.position;
        knockbacked = true;
        transform.Translate(dir.normalized * knockbackVel * Time.deltaTime);
        //rb.velocity = dir.normalized * knockbackVel;

        StartCoroutine(Unknockback());
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        knockbacked = false;
    }
}
