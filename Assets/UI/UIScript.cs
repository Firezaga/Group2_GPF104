using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private const float DAMAGED_TIMER_MAX = 1.0f;

    public PlayerScript player;
    public Text scoreText;
    public Image healthBar;
    public Image healthBarDamaged;

    private float damagedHealthTimer;
    private float tempHealth;
    // Start is called before the first frame update
    void Start()
    {
        tempHealth = player.health;
        healthBarDamaged.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.score.ToString();
        if (tempHealth != player.health)
        {
            
            healthBar.fillAmount = (float)player.health / (float)player.healthMax;
            if (tempHealth > player.health)
                healthBarDamaged.fillAmount = tempHealth / (float)player.healthMax;
            damagedHealthTimer = DAMAGED_TIMER_MAX;
            tempHealth = player.health;
        }
        

        if (player.health <= 0)
            SceneManager.LoadScene("GameOver");
        damagedHealthTimer -= Time.deltaTime;
        if (damagedHealthTimer < 0)
        {
            if (healthBar.fillAmount < healthBarDamaged.fillAmount)
            {
                float shrinkSpeed = 0.5f;
                healthBarDamaged.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
