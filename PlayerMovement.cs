using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public List<Attack> attacks = new List<Attack>();
    public float speed;
    public float score;
    public float jumpForce;
    public float jumpTime;
    public Animator anim;
    public GameObject jumpFX;
    public Transform transformFX;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float resetTime;
    public float health = 5;
    public float money = 0;
    public float food = 0;
    public float damage = 1;
    private float moveInput;
    private Rigidbody2D rb;
    private float jumpTimeCounter;
    private bool IsJumping;
    private bool isGrounded;
    private bool moveDirection = false;//false == right,true==left
    private bool boolToSetB;
    private string boolToSetS;
    public bool gamePause;
    public bool gamePauseN;
    public string intString;
    public Color color;
    public CameraShake cameraS;
    public AudioManager am;
    private bool colorChange = false;
    private int i = 0;
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        rb = this.GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetInt(intString) == 0)
        {
           
            gamePauseN = true;
        }
    }
    public IEnumerator GotHit()
    {
        am.Play("Hit");
        colorChange = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(0.2f);
        colorChange = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Attack()
    {
        
        if (i == 0)
        {
            am.Play("SwordAttack");
        }
        if (i == 1)
        {
            am.Play("MagicAttack");
        }
        if (attacks[i].coolDown <= 0)
        {
            if (moveDirection == false)
            {
                attacks[i].weaponColliderRight.SetActive(true);
            }
            if (moveDirection == true)
            {
                attacks[i].weaponColliderLeft.SetActive(true);
            }
            attacks[i].coolDown = attacks[i].attackCoolDown;
            anim.SetBool(attacks[i].boolToSetS, true);
            StartCoroutine("TriggerFX");
            boolToSetB = false;
            boolToSetS = attacks[i].boolToSetS;
            StartCoroutine("ResetVal");
            resetTime = attacks[i].resetTime;
        }
    } 
    public IEnumerator TriggerFX()
    {

        yield return new WaitForSeconds(attacks[i].triggerImpactFXDelay);
        GameObject g = Instantiate(attacks[i].HitFX, transformFX);
        g.GetComponent<DestroyFX>().destroyFX = true;
        if (moveDirection == false)
        {
            g.transform.position = attacks[i].ImpactPositionRight.transform.position;
        }
        if (moveDirection == true)
        {
            g.transform.position = attacks[i].ImpactPositionLeft.transform.position;
        }
        StartCoroutine(cameraS.BigShake());
    }

    public IEnumerator ResetVal()
    {
        yield return new WaitForSeconds(resetTime);
        anim.SetBool(boolToSetS,boolToSetB);
        attacks[i].weaponColliderRight.SetActive(false);
        attacks[i].weaponColliderLeft.SetActive(false);
    }
    void Update()    
    {
        if (!gamePauseN)
        {
            if (!gamePause)
            {
                score += Time.deltaTime * 2;
            }
        }
        if (colorChange == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            i = 0;
           Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            i = 1;
            Attack();
        }
        foreach (Attack a in attacks)
        {
            a.coolDown -= Time.deltaTime;
        }
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
            GameObject g = Instantiate(jumpFX,transformFX);
            g.GetComponent<DestroyFX>().destroyFX = true;
            g.transform.position = feetPos.transform.position;
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
        if (score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", score);
            PlayerPrefs.SetFloat("Currentscore", score);
        }
        else
        {
            PlayerPrefs.SetFloat("Currentscore", score);
        }
        SceneManager.LoadScene(3);
    }
}
