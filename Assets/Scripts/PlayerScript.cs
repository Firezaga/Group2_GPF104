using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CoinGenerator CoinGenerator;

    public float jumpForce;
    bool isGrounded;
    bool isJumping;
    bool jumpKeyHeld;
    public Vector2 counterJumpForce;

    public int health;
    public int healthMax;
    public int score;

    [SerializeField]
    private int coinValue;
    private int coinMultiplier;

    Rigidbody2D RB;
    Animator animator;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        health = healthMax;
        score = 0;
        coinMultiplier = 1;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyHeld = true;
            if (isGrounded)
            {
                isJumping = true;
                isGrounded = false;
                RB.AddForce(Vector2.up * jumpForce * RB.mass, ForceMode2D.Impulse);
                animator.SetBool("isJumping", true);
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }



        if (health <= 0)
        {
            PlayerPrefs.SetInt("currentScore", score);
            PlayerPrefs.Save();
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (!jumpKeyHeld && Vector2.Dot(RB.velocity, Vector2.up) > 0)
            {
                RB.AddForce(counterJumpForce * RB.mass);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            if (health > 0)
                health -= 25;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AddScore(coinValue, coinMultiplier);
            coinMultiplier++;
            Destroy(collision.gameObject);
            CoinGenerator.GenerateNext();
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            health += 25;
            if (health >= healthMax)
            {
                health = healthMax;
            }
            Destroy(collision.gameObject);
            CoinGenerator.GenerateNext();
        }
    }

    public void AddScore(int scoreToAdd, int multiplier)
    {
        score += scoreToAdd * multiplier;
    }

    public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }
}
