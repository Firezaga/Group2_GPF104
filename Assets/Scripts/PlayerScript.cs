using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CoinGenerator CoinGenerator;

    public float jumpForce;

    public int health;
    public int score;

    [SerializeField]
    private int coinValue;
    private int coinMultiplier;

    bool isGrounded = false;
    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        health = 100;
        score = 0;
        coinMultiplier = 1;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }
        if (health <= 0)
            Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
                isGrounded = true;
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
    }

    public void AddScore(int scoreToAdd, int multiplier)
    {
        score += scoreToAdd * multiplier;
    }
}
