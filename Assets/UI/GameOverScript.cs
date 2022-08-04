using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text HIGHSCORE;
    public Text currentScore;
    public InputField playerName;
    string hs1Name;
    string hs2Name;
    string hs3Name;
    string csName;
    int hs1 = 0;
    int hs2 = 0;
    int hs3 = 0;
    int cs;

    private void Start()
    {
        hs1 = PlayerPrefs.GetInt("highScore1");
        hs1Name = PlayerPrefs.GetString("highScore1Name");
        hs2 = PlayerPrefs.GetInt("highScore2");
        hs2Name = PlayerPrefs.GetString("highScore2Name");
        hs3 = PlayerPrefs.GetInt("highScore3");
        hs3Name = PlayerPrefs.GetString("highScore3Name");
        cs = PlayerPrefs.GetInt("currentScore");

        currentScore.text = cs.ToString();
    }

    public void MainMenu()
    {
        UpdateHighScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        UpdateHighScore();
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {
        UpdateHighScore();
        SceneManager.LoadScene("HighScore");
    }

    public void ExitGame()
    {
        UpdateHighScore();
        Application.Quit();
    }

    public void UpdateName()
    {
        csName = playerName.text;
        currentScore.text = csName + ": " + cs.ToString();

        if (cs >= hs1)
        {
            hs3 = hs2;
            hs3Name = hs2Name;
            hs2 = hs1;
            hs2Name = hs1Name;
            hs1 = cs;
            hs1Name = csName;
            HIGHSCORE.text = "***TOP HIGHSCORE***";
        }
        else if (cs >= hs2)
        {
            hs3 = hs2;
            hs3Name = hs2Name;
            hs2 = cs;
            hs2Name = csName;
            HIGHSCORE.text = "***HIGHSCORE***";
        }
        else if (cs >= hs3)
        {
            hs3 = cs;
            hs3Name = csName;
            HIGHSCORE.text = "***HIGHSCORE***";
        }
    }

    void UpdateHighScore()
    {
        PlayerPrefs.SetInt("highScore1", hs1);
        PlayerPrefs.SetString("highScore1Name", hs1Name);
        PlayerPrefs.SetInt("highScore2", hs2);
        PlayerPrefs.SetString("highScore2Name", hs2Name);
        PlayerPrefs.SetInt("highScore3", hs3);
        PlayerPrefs.SetString("highScore3Name", hs3Name);
        PlayerPrefs.Save();
    }
}
