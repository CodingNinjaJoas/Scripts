using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpTime;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float health = 5;
    public float money = 0;

    private float moveInput;
    private Rigidbody2D rb;
    private float jumpTimeCounter;
    private bool IsJumping;
    private bool isGrounded;
    private bool moveDirection = false;//false == right,true==left
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            moveDirection = false;
        }
        if (moveInput < 0)
        {
            moveDirection = true;
        }
        FlipUI();
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            if (jumpTimeCounter >= 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }
    public void FlipUI()
    {
        if (moveDirection == false)
        {

            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (moveDirection == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;

        }
    }
    public void Die()
    {
        Debug.Log("Die");
    }
}
