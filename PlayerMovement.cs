using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpTime;
    public Animator anim;
    public float hitCoolDown;
    public float shotHitCoolDown;
    private float cooldDown;
    private float shotCoolDown;
    public GameObject hitFX;
    public GameObject hitFXShot;
    public Transform transformFX;
    public Transform swordImpactPositionLeft;
    public Transform swordImpactPositionRight;
    public GameObject weaponColliderRight;
    public GameObject weaponColliderLeft;
    public GameObject shotWeaponColliderLeft;
    public GameObject shotWeaponColliderRight;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float resetTime;
    public float resetTimeShot;
    public float resetTimeSword;
    public float health = 5;
    public float money = 0;
    public float food = 0;
    public float triggerImpactFXDelay = 0.2f;
    public float triggerImpactFXDelayShot = 0.2f;
    private float moveInput;
    private Rigidbody2D rb;
    private float jumpTimeCounter;
    private bool IsJumping;
    private bool isGrounded;
    private bool moveDirection = false;//false == right,true==left
    private bool boolToSetB;
    private string boolToSetS;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Sword()
    {
        if (cooldDown <= 0)
        {
            if (moveDirection == false)
            {
                weaponColliderRight.SetActive(true);
            }
            if (moveDirection == true)
            {
                weaponColliderLeft.SetActive(true);
            }
            cooldDown = hitCoolDown;
            anim.SetBool("SwordHit", true);
            StartCoroutine("TriggerFX");
            boolToSetB = false;
            boolToSetS = "SwordHit";
            StartCoroutine("ResetVal");
            resetTime = resetTimeSword;
        }
    }
       public void Shot()
        {
            if (shotCoolDown <= 0)
            {
                if (moveDirection == false)
                {
                    shotWeaponColliderRight.SetActive(true);
                }
                if (moveDirection == true)
                {
                    shotWeaponColliderLeft.SetActive(true);
                }
                shotCoolDown = shotHitCoolDown;
                anim.SetBool("Shot", true);
                StartCoroutine("TriggerFXShot");
                boolToSetB = false;
                boolToSetS = "Shot";
                StartCoroutine("ResetVal");
            resetTime = resetTimeShot;
            }

        }
    
    public IEnumerator TriggerFX()
    {
        yield return new WaitForSeconds(triggerImpactFXDelay);
        GameObject g = Instantiate(hitFX, transformFX);
        if (moveDirection == false)
        {
            g.transform.position = swordImpactPositionRight.transform.position;
        }
        if (moveDirection == true)
        {
            g.transform.position = swordImpactPositionLeft.transform.position;
        }
    }
    public IEnumerator TriggerFXShot()
    {
        yield return new WaitForSeconds(triggerImpactFXDelayShot);
        GameObject g = Instantiate(hitFXShot, transformFX);
        if (moveDirection == false)
        {
            g.transform.position = shotWeaponColliderRight.transform.position;
        }
        if (moveDirection == true)
        {
            g.transform.position = shotWeaponColliderRight.transform.position;
        }
    }
    public IEnumerator ResetVal()
    {
        yield return new WaitForSeconds(resetTime);
        anim.SetBool(boolToSetS,boolToSetB);
        weaponColliderLeft.SetActive(false);
        weaponColliderRight.SetActive(false);
    }
    void Update()    
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sword();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shot();
        }
        cooldDown -= Time.deltaTime;
        shotCoolDown -= Time.deltaTime;
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
