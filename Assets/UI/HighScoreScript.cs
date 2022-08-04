using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreScript : MonoBehaviour
{
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("highScore1Name"))
            highScore1.text = "1. " + PlayerPrefs.GetString("highScore1Name") + ": " + PlayerPrefs.GetInt("highScore1");
        if (PlayerPrefs.HasKey("highScore2Name"))
            highScore2.text = "2. " + PlayerPrefs.GetString("highScore2Name") + ": " + PlayerPrefs.GetInt("highScore2");
        if (PlayerPrefs.HasKey("highScore3Name"))
            highScore3.text = "3. " + PlayerPrefs.GetString("highScore3Name") + ": " + PlayerPrefs.GetInt("highScore3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
