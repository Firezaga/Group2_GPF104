using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public PlayerScript player;
    public Text healthText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + player.health;
        scoreText.text = player.score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
