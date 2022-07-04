using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public PlayerScript player;
    public Text scoreText;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.score.ToString();
        healthBar.fillAmount = (float)player.health / 100.0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
